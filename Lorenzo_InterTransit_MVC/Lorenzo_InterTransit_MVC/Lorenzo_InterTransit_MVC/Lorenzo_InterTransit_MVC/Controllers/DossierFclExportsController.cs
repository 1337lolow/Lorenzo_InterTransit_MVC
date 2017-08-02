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

namespace Lorenzo_InterTransit_MVC.Controllers
{
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

        // GET: DossierFclExports
        public ActionResult Index(string searchString)
        {
            var dossierFclExports = db.DossierFclExports.Include(d => d.Client).Include(d => d.InstruTransporteurs).Include(d => d.Bookings);
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

        // GET: DossierFclExports/Create
        public ActionResult Create()
        {
           
            
            ViewBag.numDoss = (DateTime.Now.Year + "E" + leDoss.numDossCompteur().ToString());
            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_NOMRAIS");
            return View();
        }

        // POST: DossierFclExports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FCL_ID,CLT_ID,FCL_STATUT,FCL_DATEMAJ")] DossierFclExport dossierFclExport)
        {
            if (ModelState.IsValid)
            {
                db.DossierFclExports.Add(dossierFclExport);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CLT_ID = new SelectList(db.Clients, "CLT_ID", "CLT_REF", dossierFclExport.CLT_ID);
            return View(dossierFclExport);
        }

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
            if (ModelState.IsValid)
            {
                db.Entry(dossierFclExport).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
