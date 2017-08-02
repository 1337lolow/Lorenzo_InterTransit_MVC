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
using System.Data.Entity.Infrastructure;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class InstruTransporteursController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: InstruTransporteurs
        public async Task<ActionResult> Index()
        {
            var instruTransporteurs = db.InstruTransporteurs.Include(i => i.DossierFclExport).Include(i => i.MAD).Include(i => i.Transporteur);
            return View(await instruTransporteurs.ToListAsync());
        }

        // GET: InstruTransporteurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstruTransporteur instruTransporteur = await db.InstruTransporteurs.FindAsync(id);
            if (instruTransporteur == null)
            {
                return HttpNotFound();
            }
            return View(instruTransporteur);
        }

        // GET: InstruTransporteurs/Create
        public ActionResult Create()
        {
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID");
            ViewBag.MAD_ID = new SelectList(db.MADs, "MAD_ID", "MAD_LIEU_ENLEV");
            ViewBag.TRS_REF = new SelectList(db.Transporteurs, "TRS_REF", "TRS_NOMRAIS");
            return View();
        }

        // POST: InstruTransporteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INSTR_NUMOFR,MAD_ID,FCL_ID,TRS_REF,INSTR_ADRS_EMPTG,INSTR_ADRS_LIVRAISION,INSTR_DATEARRIVEE,INSTR_DATEDEPART,INSTR_LIEU_ARRIVEE,INSTR_LIEU_DEPART,INSTR_OBS")] InstruTransporteur instruTransporteur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.InstruTransporteurs.Add(instruTransporteur);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", new { Controller = "DossierFclExports", id = instruTransporteur.FCL_ID });
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", instruTransporteur.FCL_ID);
            ViewBag.MAD_ID = new SelectList(db.MADs, "MAD_ID", "MAD_LIEU_ENLEV", instruTransporteur.MAD_ID);
            ViewBag.TRS_REF = new SelectList(db.Transporteurs, "TRS_REF", "TRS_NOMRAIS", instruTransporteur.TRS_REF);
            return View(instruTransporteur);
        }

        // GET: InstruTransporteurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstruTransporteur instruTransporteur = await db.InstruTransporteurs.FindAsync(id);
            if (instruTransporteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", instruTransporteur.FCL_ID);
            ViewBag.MAD_ID = new SelectList(db.MADs, "MAD_ID", "MAD_LIEU_ENLEV", instruTransporteur.MAD_ID);
            ViewBag.TRS_REF = new SelectList(db.Transporteurs, "TRS_REF", "TRS_NOMRAIS", instruTransporteur.TRS_REF);
            return View(instruTransporteur);
        }

        // POST: InstruTransporteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INSTR_NUMOFR,MAD_ID,FCL_ID,TRS_REF,INSTR_ADRS_EMPTG,INSTR_ADRS_LIVRAISION,INSTR_DATEARRIVEE,INSTR_DATEDEPART,INSTR_LIEU_ARRIVEE,INSTR_LIEU_DEPART,INSTR_OBS")] InstruTransporteur instruTransporteur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(instruTransporteur).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", new { Controller = "DossierFclExports", id = instruTransporteur.FCL_ID });

                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", instruTransporteur.FCL_ID);
            ViewBag.MAD_ID = new SelectList(db.MADs, "MAD_ID", "MAD_LIEU_ENLEV", instruTransporteur.MAD_ID);
            ViewBag.TRS_REF = new SelectList(db.Transporteurs, "TRS_REF", "TRS_NOMRAIS", instruTransporteur.TRS_REF);
            return View(instruTransporteur);
        }

        // GET: InstruTransporteurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstruTransporteur instruTransporteur = await db.InstruTransporteurs.FindAsync(id);
            if (instruTransporteur == null)
            {
                return HttpNotFound();
            }
            return View(instruTransporteur);
        }

        // POST: InstruTransporteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InstruTransporteur instruTransporteur = await db.InstruTransporteurs.FindAsync(id);
            string idFcl = instruTransporteur.FCL_ID;
            db.InstruTransporteurs.Remove(instruTransporteur);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { Controller = "DossierFclExports", id = idFcl });

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
