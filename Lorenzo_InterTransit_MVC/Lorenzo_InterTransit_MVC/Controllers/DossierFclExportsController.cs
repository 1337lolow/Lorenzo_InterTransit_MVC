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

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class DossierFclExportsController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: DossierFclExports
        public ActionResult Index()
        {
            
            
            var dossierFclExports = db.DossierFclExports.Include(d => d.Client).Include(d => d.InstruTransporteurs).Include(d => d.Bookings);
            return View(dossierFclExports);
        }

        // GET: DossierFclExports/Details/5
        public async Task<ActionResult> Details(string id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //à mettre dans une classeDAO
            var viewModel = new DossierFCLDetail();
            if (!String.IsNullOrEmpty(id))
            {
                var ctList = (from ppl in db.DossierFclExports
                              join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID                              
                              join ct in db.Conteneurs on bk.BKG_NUM equals ct.BKG_NUM
                              where ppl.FCL_ID == id
                              select ct).ToList();

                var transList = (from ppl in db.DossierFclExports
                                 join it in db.InstruTransporteurs on id equals it.FCL_ID
                                 join tr in db.Transporteurs on it.TRS_REF equals tr.TRS_REF
                                 where ppl.FCL_ID == id
                                 select tr).ToList();

                var madList = (from ppl in db.DossierFclExports
                               join it in db.InstruTransporteurs on id equals it.FCL_ID
                               join md in db.MADs on it.MAD_ID equals md.MAD_ID
                               where ppl.FCL_ID == id
                               select md).ToList();

                var cmList = (from ppl in db.DossierFclExports
                              join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                              join cm in db.CompagnieMaritimes on bk.CM_REF equals cm.CM_REF
                              where ppl.FCL_ID == id
                              select cm).ToList();

                var cli = (from ppl in db.DossierFclExports
                           join cl in db.Clients on ppl.CLT_ID equals cl.CLT_ID
                           where ppl.FCL_ID == id
                           select cl).ToList();

                var ligneVente = (from ppl in db.DossierFclExports
                                  join lv in db.LigneDeVentes on ppl.FCL_ID equals lv.FCL_ID
                                  where ppl.FCL_ID == id
                                  select lv).ToList();
                int idDevis = (from ppl in ligneVente
                              select ppl.Devi.DEVIS_ID).FirstOrDefault();

                var devisDetail = (from ppl in db.Devis
                                   where ppl.DEVIS_ID == idDevis
                                   select ppl).ToList();

                List<Marchandise> lstMarch = new List<Marchandise>();
                foreach (var mc in ctList)
                {
                    foreach(var m in mc.Marchandises)
                    {
                        lstMarch.Add(m);
                    }                  
                }


                ViewBag.FclID = id.ToString();
                viewModel.Clients = cli;
                viewModel.DossierFclExports = db.DossierFclExports.Where(x => x.FCL_ID == id).Include(d => d.Bookings).Include(d => d.InstruTransporteurs);
                viewModel.InstruTrans = viewModel.DossierFclExports.Where(x => x.FCL_ID == id.ToString()).Single().InstruTransporteurs;
                viewModel.Bookings = viewModel.DossierFclExports.Where(x => x.FCL_ID == id.ToString()).Single().Bookings;
                viewModel.Conteneurs = ctList;
                viewModel.Marchandises = lstMarch;
                viewModel.Transporteurs = transList;
                viewModel.CompagnieMaritimes = cmList;
                viewModel.Mads = madList;
                viewModel.LigneDeVentes = ligneVente;
                viewModel.Devis = devisDetail ;

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
            List<int> lstNum = new List<int>();
            var lastDoss = (from ppl in db.DossierFclExports                            
                            select ppl).ToList();
            foreach(DossierFclExport doss in lastDoss)
            {
                int x = Convert.ToInt32(doss.FCL_ID.Substring(5, (doss.FCL_ID.Length) - 5));
                lstNum.Add(x);
            }
            var jin = (from ppl in lstNum
                       select ppl).Max();
            //string numDoss = lastDoss.FCL_ID;
            
            jin++;
            ViewBag.numDoss = (DateTime.Now.Year + "E" + jin.ToString());
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
