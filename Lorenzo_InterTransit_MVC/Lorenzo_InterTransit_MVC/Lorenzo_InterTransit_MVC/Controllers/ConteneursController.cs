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
    public class ConteneursController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: Conteneurs
        public async Task<ActionResult> Index()
        {
            var conteneurs = db.Conteneurs.Include(c => c.Booking).Include(c => c.TypeTC);
            return View(await conteneurs.ToListAsync());
        }

        // GET: Conteneurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteneur conteneur = await db.Conteneurs.FindAsync(id);
            if (conteneur == null)
            {
                return HttpNotFound();
            }
            return View(conteneur);
        }

        // GET: Conteneurs/Create
        public ActionResult Create()
        {
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "FCL_ID");
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE");
            return View();
        }

        // POST: Conteneurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CTN_REF,TYTC_ID,BKG_NUM,CTN_PLOMBAGE,CTN_DATEPLOMBAGE,CTN_REFCOX,CTN_OBS")] Conteneur conteneur)
        {
            if (ModelState.IsValid)
            {
                db.Conteneurs.Add(conteneur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "FCL_ID", conteneur.BKG_NUM);
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE", conteneur.TYTC_ID);
            return View(conteneur);
        }

        // GET: Conteneurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteneur conteneur = await db.Conteneurs.FindAsync(id);
            if (conteneur == null)
            {
                return HttpNotFound();
            }
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "FCL_ID", conteneur.BKG_NUM);
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE", conteneur.TYTC_ID);
            return View(conteneur);
        }

        // POST: Conteneurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CTN_REF,TYTC_ID,BKG_NUM,CTN_PLOMBAGE,CTN_DATEPLOMBAGE,CTN_REFCOX,CTN_OBS")] Conteneur conteneur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conteneur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "FCL_ID", conteneur.BKG_NUM);
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE", conteneur.TYTC_ID);
            return View(conteneur);
        }

        // GET: Conteneurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteneur conteneur = await db.Conteneurs.FindAsync(id);
            if (conteneur == null)
            {
                return HttpNotFound();
            }
            return View(conteneur);
        }

        // POST: Conteneurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Conteneur conteneur = await db.Conteneurs.FindAsync(id);
            db.Conteneurs.Remove(conteneur);
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
