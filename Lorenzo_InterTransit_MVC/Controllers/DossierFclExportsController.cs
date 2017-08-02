using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using Lorenzo_InterTransit_MVC.ViewModels;
using DAL.DAO;
using BLL;
using System.Data.Entity.Infrastructure;
using BLL.ViewModels;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    /// <summary>
    /// class controller de Dossier FCL export
    /// </summary>
    public class DossierFclExportsController : Controller
    {
        InterTransit db = new InterTransit();
        DevisManager leDevisDuDoss = new DevisManager();
        MarchandiseManager laMarchDuTC = new MarchandiseManager();
        ConteneursManager leTCduDoss = new ConteneursManager();
        ClientManager leCliDuDoss = new ClientManager();
        BookingManager lesBkDuDoss = new BookingManager();
        TransporteurManager lesTransDuDoss = new TransporteurManager();
        DossierFclManager leDoss = new DossierFclManager();
        LigneDeVenteManager ldvDuDoss = new LigneDeVenteManager();
        MADManager madDuDoss = new MADManager();
        InstruTransporteurManager instruDoss = new InstruTransporteurManager();
        CompagnieMaritimeManager cmDuDoss = new CompagnieMaritimeManager();
        DossierFclExport rezDoss = new DossierFclExport();
        Booking rezBkg = new Booking();
        List<Conteneur> lstTC = new List<Conteneur>();
        List<Marchandise> lsMarchandises = new List<Marchandise>();
        InstruTransporteur rezInstru = new InstruTransporteur();
        Transporteur rezTrans = new Transporteur();
        MAD rezMad = new MAD();
        Devi rezDevi = new Devi();
        List<LigneDeVente> lstLV = new List<LigneDeVente>();
        Client rezCli = new Client();
        CompagnieMaritime rezCompa = new CompagnieMaritime();

        Outils outils = new Outils();
        // GET: DossierFclExports
        public ActionResult Index(string searchString)
        {
            var dossierFclExports = db.DossierFclExports.Include(d => d.Client).Include(d => d.InstruTransporteurs).Include(d => d.Bookings);

            //si la saerchstring envoyé en GET via la barre de recherche de dossier et non null ou non vide alors :
            if (!String.IsNullOrEmpty(searchString))
            {
                DossierFclManager jinzo = new DossierFclManager();
                //dossierFclExports = db.DossierFclExports.Where(i => i.FCL_ID.Contains(searchString));
                List<DossierFclExport> lstdoss = jinzo.searchDossById(searchString);
                return View(lstdoss);
            }

            return View(dossierFclExports);
        }

        // GET: DossierFclExports/Details/5
        public ActionResult Details(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //à mettre dans une classeDAO
            var viewModel = new DossierFCLDetail();
            if (!String.IsNullOrEmpty(id))
            {

                ViewBag.FclID = id.ToString();
                viewModel.Clients = leCliDuDoss.GetClientByIdDoss(id); ;
                viewModel.DossierFclExports = leDoss.GetDossById(id);
                viewModel.InstruTrans = instruDoss.GetInstruTransByIdDoss(id);
                viewModel.Bookings = lesBkDuDoss.getBookingByIdDoss(id);
                viewModel.Conteneurs = leTCduDoss.getAllTCByIdDoss(id);
                viewModel.Marchandises = laMarchDuTC.getMarchByIdFcl(id);
                viewModel.Transporteurs = lesTransDuDoss.GetTransByIdDoss(id);
                viewModel.CompagnieMaritimes = cmDuDoss.GetCMByIdDoss(id);
                viewModel.Mads = madDuDoss.GetMadByIdDoss(id);
                viewModel.LigneDeVentes = ldvDuDoss.GetLigneDeVenteByIdDoss(id);
                viewModel.Devis = leDevisDuDoss.getDevisByIDDoss(id, ldvDuDoss.GetLigneDeVenteByIdDoss(id));

            }
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        public ActionResult ResumeFcl()
        {
            var viewModel = new ResumeDossierFcl();
            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResumeFcl(FormCollection fc)
        {
            try
            {
                var viewModel = new ResumeDossierFcl();
                viewModel.Clients = rezCli;
                viewModel.DossierFclExports = rezDoss;
                viewModel.Bookings = rezBkg;
                viewModel.InstruTrans = rezInstru;
                viewModel.Transporteurs = rezTrans;
                viewModel.Mads = rezMad;
                viewModel.Devis = rezDevi;
                viewModel.CompagnieMaritimes = rezCompa;
                viewModel.Conteneurs = lstTC;
                viewModel.Marchandises = lsMarchandises;
                viewModel.LigneDeVentes = lstLV;                               

                //Instanciation de l'objet client
                rezCli.CLT_ID = leCliDuDoss.NewIdClient();
                rezCli.CLT_REF = fc["Clients.CLT_REF"];
                rezCli.CLT_NOMRAIS = fc["Clients.CLT_NOMRAIS"];
                if (!String.IsNullOrEmpty(fc["Clients.CLT_SIRET"]))
                {
                    rezCli.CLT_SIRET = Convert.ToInt32(fc["Clients.CLT_SIRET"]);
                }
                else
                {
                    rezCli.CLT_SIRET = 0;
                }

                rezCli.CLT_ADRESSE = fc["Clients.CLT_ADRESSE"];
                rezCli.CLT_CP = fc["Clients.CLT_CP"];
                rezCli.CLT_VILLE = fc["Clients.CLT_VILLE"];
                rezCli.CLT_PAYS = fc["Clients.CLT_PAYS"];
                leCliDuDoss.AddClient(rezCli);
                //db.SaveChanges();

                //Instanciation de l'objet dossier
                rezDoss.FCL_ID = (DateTime.Now.Year + "E" + leDoss.numDossCompteur().ToString());
                rezDoss.CLT_ID = rezCli.CLT_ID;
                leDoss.AddDossier(rezDoss);

                //Instanciation de l'objet Transporteur
                rezTrans.TRS_REF = lesTransDuDoss.numTransCompteur().ToString();
                rezTrans.TYTRANS_ID =Convert.ToInt32(fc["TYTRANS_ID"]);
                rezTrans.TRS_NOMRAIS = fc["Transporteurs.TRS_NOMRAIS"];
                lesTransDuDoss.AddTrans(rezTrans);

                //Instanciation de l'objet MAD
                rezMad.MAD_ID = madDuDoss.NumMad();
                rezMad.MAD_LIEU_ENLEV = fc["Mads.MAD_LIEU_ENLEV"];
                rezMad.MAD_ADRES_ENLEV = fc["Mads.MAD_ADRES_ENLEV"];
                if(!String.IsNullOrEmpty(fc["Mads.MAD_DATE"]))
                {
                    rezMad.MAD_DATE = Convert.ToDateTime(fc["Mads.MAD_DATE"]);
                }
                else
                {
                    rezMad.MAD_DATE = DateTime.Now;
                }
                madDuDoss.AddMad(rezMad);


                //Instanciation de l'objet Instruction Transporteur
                rezInstru.INSTR_NUMOFR = instruDoss.NumOffreAuto();
                rezInstru.MAD_ID = rezMad.MAD_ID;
                rezInstru.FCL_ID = rezDoss.FCL_ID;
                rezInstru.TRS_REF = rezTrans.TRS_REF;
                instruDoss.AddInstruTrans(rezInstru);

                //Instanciation de l'objet CompagnieMaritime
                rezCompa.CM_REF = cmDuDoss.numCompMaritime().ToString();
                rezCompa.CM_NOMRAIS = fc["CompagnieMaritimes.CM_NOMRAIS"];
                rezCompa.CM_SIRET = 0;
                rezCompa.CM_ADRESSE = "";
                rezCompa.CM_CP = "";
                rezCompa.CM_VILLE = fc["CompagnieMaritimes.CM_VILLE"];
                cmDuDoss.AddCM(rezCompa);

                //Instanciation de l'objet Booking
                rezBkg.BKG_ID = lesBkDuDoss.CompteurNumBkg();
                rezBkg.BKG_NUM = fc["Bookings.BKG_NUM"];
                rezBkg.FCL_ID = rezDoss.FCL_ID;
                rezBkg.CM_REF = rezCompa.CM_REF;
                rezBkg.BKG_NOMNAVIRE = fc["Bookings.BKG_NOMNAVIRE"];
                rezBkg.BKG_DATE = DateTime.Now;
                if (!String.IsNullOrEmpty(fc["Bookings.BKG_ETA"]))
                {
                    rezBkg.BKG_ETA = Convert.ToDateTime(fc["Bookings.BKG_ETA"]);
                }
                else
                {
                    rezBkg.BKG_ETA = DateTime.Now;
                }
                if(!String.IsNullOrEmpty(fc["Bookings.BKG_ETD"]))
                {
                    rezBkg.BKG_ETD = Convert.ToDateTime(fc["Bookings.BKG_ETD"]);
                }
                else
                {
                    rezBkg.BKG_ETD = DateTime.Now;
                }
                rezBkg.BKG_FORWARDER = "";
                rezBkg.BKG_LOADTERM = "";
                rezBkg.BKG_NUMVYG = "";
                rezBkg.BKG_PORTARRIVEE = fc["Bookings.BKG_PORTARRIVEE"];
                rezBkg.BKG_PORTDEPART = fc["Bookings.BKG_PORTDEPART"];
                rezBkg.BKG_PORTFORWARDER = "";
                rezBkg.BKG_REFCOTATION = "";
                rezBkg.BKG_OBS = "";
                rezBkg.BKG_REFBL = fc["Bookings.BKG_REFBL"];
                lesBkDuDoss.AddBooking(rezBkg);


                ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE");
                return RedirectToAction("Index", new { Controller = "DossierFclExports" });
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return RedirectToAction("Details", new { Controller = "DossierFclExports", id = rezDoss.FCL_ID });

        }

     
        public ActionResult EditResumeFcl (string id)
        {
            var viewModel = new ResumeDossierFcl();
            viewModel.Clients = leCliDuDoss.GetClientByIdDoss(id).FirstOrDefault();
            viewModel.DossierFclExports = leDoss.GetDossById(id).FirstOrDefault();
            viewModel.Bookings = lesBkDuDoss.getBookingByIdDoss(id).FirstOrDefault();
            viewModel.CompagnieMaritimes = cmDuDoss.GetCMByIdDoss(id).FirstOrDefault();
            viewModel.Mads = madDuDoss.GetMadByIdDoss(id).FirstOrDefault();
            viewModel.Transporteurs = lesTransDuDoss.GetTransByIdDoss(id).FirstOrDefault();
            viewModel.InstruTrans = instruDoss.GetInstruTransByIdDoss(id).FirstOrDefault();
            viewModel.Conteneurs = leTCduDoss.getAllTCByIdDoss(id);
            viewModel.Marchandises = laMarchDuTC.getMarchByIdFcl(id);

            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE");



            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditResumeFcl(FormCollection fc)
        {
            try
            {
                var viewModel = new ResumeDossierFcl();
                viewModel.Clients = rezCli;
                viewModel.DossierFclExports = rezDoss;
                viewModel.Bookings = rezBkg;
                viewModel.InstruTrans = rezInstru;
                viewModel.Transporteurs = rezTrans;
                viewModel.Mads = rezMad;
                viewModel.Devis = rezDevi;
                viewModel.CompagnieMaritimes = rezCompa;
                viewModel.Conteneurs = lstTC;
                viewModel.Marchandises = lsMarchandises;
                viewModel.LigneDeVentes = lstLV;

                //Instanciation de l'objet client
                rezCli.CLT_ID = leCliDuDoss.GetClientByIdDoss(fc["DossierFclExports.FCL_ID"]).FirstOrDefault().CLT_ID;
                rezCli.CLT_REF = fc["Clients.CLT_REF"];
                rezCli.CLT_NOMRAIS = fc["Clients.CLT_NOMRAIS"];
                if (!String.IsNullOrEmpty(fc["Clients.CLT_SIRET"]))
                {
                    rezCli.CLT_SIRET = Convert.ToInt32(fc["Clients.CLT_SIRET"]);
                }
                else
                {
                    rezCli.CLT_SIRET = 0;
                }
                rezCli.CLT_ADRESSE = fc["Clients.CLT_ADRESSE"];
                rezCli.CLT_CP = fc["Clients.CLT_CP"];
                rezCli.CLT_VILLE = fc["Clients.CLT_VILLE"];
                rezCli.CLT_PAYS = fc["Clients.CLT_PAYS"];
                db.Entry(rezCli).State = EntityState.Modified;



                //Instanciation de l'objet dossier
                rezDoss.FCL_ID = fc["DossierFclExports.FCL_ID"];
                rezDoss.CLT_ID = rezCli.CLT_ID;
                db.Entry(rezDoss).State = EntityState.Modified;


                //Instanciation de l'objet Transporteur
                rezTrans.TRS_REF = lesTransDuDoss.GetTransByIdDoss(fc["DossierFclExports.FCL_ID"]).FirstOrDefault().TRS_REF;
                rezTrans.TYTRANS_ID = Convert.ToInt32(fc["TYTRANS_ID"]);
                rezTrans.TRS_NOMRAIS = fc["Transporteurs.TRS_NOMRAIS"];
                db.Entry(rezTrans).State = EntityState.Modified;



                //Instanciation de l'objet MAD
                rezMad.MAD_ID = fc["Mads.MAD_ID"];
                rezMad.MAD_LIEU_ENLEV = fc["Mads.MAD_LIEU_ENLEV"];
                rezMad.MAD_ADRES_ENLEV = fc["Mads.MAD_ADRES_ENLEV"];
                if (!String.IsNullOrEmpty(fc["Mads.MAD_DATE"]))
                {
                    rezMad.MAD_DATE = Convert.ToDateTime(fc["Mads.MAD_DATE"]);
                }
                else
                {
                    rezMad.MAD_DATE = DateTime.Now;
                }
                db.Entry(rezMad).State = EntityState.Modified;



                //Instanciation de l'objet Instruction Transporteur
                rezInstru.INSTR_NUMOFR = instruDoss.GetInstruTransByIdDoss(fc["DossierFclExports.FCL_ID"]).FirstOrDefault().INSTR_NUMOFR;
                rezInstru.MAD_ID = rezMad.MAD_ID;
                rezInstru.FCL_ID = rezDoss.FCL_ID;
                rezInstru.TRS_REF = rezTrans.TRS_REF;
                db.Entry(rezInstru).State = EntityState.Modified;



                //Instanciation de l'objet CompagnieMaritime
                rezCompa.CM_REF = cmDuDoss.GetCMByIdDoss(fc["DossierFclExports.FCL_ID"]).FirstOrDefault().CM_REF;
                rezCompa.CM_NOMRAIS = fc["CompagnieMaritimes.CM_NOMRAIS"];
                rezCompa.CM_SIRET = 0;
                rezCompa.CM_ADRESSE = "";
                rezCompa.CM_CP = "";
                rezCompa.CM_VILLE = fc["CompagnieMaritimes.CM_VILLE"];
                db.Entry(rezCompa).State = EntityState.Modified;



                //Instanciation de l'objet Booking
                rezBkg.BKG_ID = lesBkDuDoss.getBookingByIdDoss(fc["DossierFclExports.FCL_ID"]).FirstOrDefault().BKG_ID;
                rezBkg.BKG_NUM = fc["Bookings.BKG_NUM"];
                rezBkg.FCL_ID = rezDoss.FCL_ID;
                rezBkg.CM_REF = rezCompa.CM_REF;
                rezBkg.BKG_NOMNAVIRE = fc["Bookings.BKG_NOMNAVIRE"];
                rezBkg.BKG_DATE = DateTime.Now;
                if (!String.IsNullOrEmpty(fc["Bookings.BKG_ETA"]))
                {
                    rezBkg.BKG_ETA = Convert.ToDateTime(fc["Bookings.BKG_ETA"]);
                }
                else
                {
                    rezBkg.BKG_ETA = DateTime.Now;
                }
                if (!String.IsNullOrEmpty(fc["Bookings.BKG_ETD"]))
                {
                    rezBkg.BKG_ETD = Convert.ToDateTime(fc["Bookings.BKG_ETD"]);
                }
                else
                {
                    rezBkg.BKG_ETD = DateTime.Now;
                }
                rezBkg.BKG_FORWARDER = "";
                rezBkg.BKG_LOADTERM = "";
                rezBkg.BKG_NUMVYG = "";
                rezBkg.BKG_PORTARRIVEE = fc["Bookings.BKG_PORTARRIVEE"];
                rezBkg.BKG_PORTDEPART = fc["Bookings.BKG_PORTDEPART"];
                rezBkg.BKG_PORTFORWARDER = "";
                rezBkg.BKG_REFCOTATION = "";
                rezBkg.BKG_OBS = "";
                rezBkg.BKG_REFBL = fc["Bookings.BKG_REFBL"];
                db.Entry(rezBkg).State = EntityState.Modified;

                db.SaveChanges();
                ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE");
                return RedirectToAction("Index", new { Controller = "DossierFclExports" });
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }


            return RedirectToAction("Details", new { Controller = "DossierFclExports", id = rezDoss.FCL_ID });
        }
        // GET: DossierFclExports/Create
        public ActionResult Create()
        {


            ViewBag.numDoss = (DateTime.Now.Year + "E" + leDoss.numDossCompteur().ToString());
            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_NOMRAIS");
            ViewBag.StatutDoss = new SelectList(outils.PeuplerDropDownListDoss());
            return View();
        }

        // POST: DossierFclExports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FCL_ID,CLT_ID,FCL_STATUT,FCL_DATEMAJ")] DossierFclExport dossierFclExport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DossierFclExports.Add(dossierFclExport);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_REF", dossierFclExport.CLT_ID);
            return View(dossierFclExport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: DossierFclExports/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierFclExport dossierFclExport = await db.DossierFclExports.FindAsync(id);
            if (dossierFclExport == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_NOMRAIS", dossierFclExport.CLT_ID);
            return View(dossierFclExport);
        }

        // POST: DossierFclExports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FCL_ID,CLT_ID,FCL_STATUT,FCL_DATEMAJ")] DossierFclExport dossierFclExport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(dossierFclExport).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_REF", dossierFclExport.CLT_ID);
            return View(dossierFclExport);
        }

        // GET: DossierFclExports/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierFclExport dossierFclExport = await db.DossierFclExports.FindAsync(id);
            if (dossierFclExport == null)
            {
                return HttpNotFound();
            }
            return View(dossierFclExport);
        }

        // POST: DossierFclExports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DossierFclExport dossierFclExport = await db.DossierFclExports.FindAsync(id);
            db.DossierFclExports.Remove(dossierFclExport);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
