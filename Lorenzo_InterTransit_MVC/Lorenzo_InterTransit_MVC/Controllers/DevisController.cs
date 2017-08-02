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

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class DevisController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: Devis
        public async Task<ActionResult> Index()
        {
            return View(await db.Devis.ToListAsync());
        }

        // GET: Devis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devi devi = await db.Devis.FindAsync(id);
            if (devi == null)
            {
                return HttpNotFound();
            }
            return View(devi);
        }

        // GET: Devis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Devis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DEVIS_ID,DEVIS_ASSURANCE,DEVIS_DATE,DEVIS_REF_FORM,DEVIS_TARIF,DEVIS_TAUX_CHG,DEVIS_TAUX_MRG,DEVIS_TOTALACHAT,DEVIS_TOTALVENTE,DEVIS_ETAT,DEVIS_REGLE,DEVIS_OBS")] Devi devi)
        {
            if (ModelState.IsValid)
            {
                db.Devis.Add(devi);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(devi);
        }

        // GET: Devis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devi devi = await db.Devis.FindAsync(id);
            if (devi == null)
            {
                return HttpNotFound();
            }
            return View(devi);
        }

        // POST: Devis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DEVIS_ID,DEVIS_ASSURANCE,DEVIS_DATE,DEVIS_REF_FORM,DEVIS_TARIF,DEVIS_TAUX_CHG,DEVIS_TAUX_MRG,DEVIS_TOTALACHAT,DEVIS_TOTALVENTE,DEVIS_ETAT,DEVIS_REGLE,DEVIS_OBS")] Devi devi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devi).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(devi);
        }

        // GET: Devis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devi devi = await db.Devis.FindAsync(id);
            if (devi == null)
            {
                return HttpNotFound();
            }
            return View(devi);
        }

        // POST: Devis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Devi devi = await db.Devis.FindAsync(id);
            db.Devis.Remove(devi);
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
