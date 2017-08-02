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
    public class MarchandisesController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: Marchandises
        public async Task<ActionResult> Index()
        {
            var marchandises = db.Marchandises.Include(m => m.NatureMarchandise);
            return View(await marchandises.ToListAsync());
        }

        // GET: Marchandises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchandise marchandise = await db.Marchandises.FindAsync(id);
            if (marchandise == null)
            {
                return HttpNotFound();
            }
            return View(marchandise);
        }

        // GET: Marchandises/Create
        public ActionResult Create()
        {
            ViewBag.NAT_MARCH_ID = new SelectList(db.NatureMarchandises, "NAT_MARCH_ID", "NAT_MARCH_LIBELLE");
            return View();
        }

        // POST: Marchandises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MARCH_ID,NAT_MARCH_ID,MARCH_DESC,MARCH_PDS,MARCH_QTE,MARCH_TYPE,MARCH_VALEURO,MARCH_DOUANE,MARCH_OBS")] Marchandise marchandise)
        {
            if (ModelState.IsValid)
            {
                db.Marchandises.Add(marchandise);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.NAT_MARCH_ID = new SelectList(db.NatureMarchandises, "NAT_MARCH_ID", "NAT_MARCH_LIBELLE", marchandise.NAT_MARCH_ID);
            return View(marchandise);
        }

        // GET: Marchandises/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchandise marchandise = await db.Marchandises.FindAsync(id);
            if (marchandise == null)
            {
                return HttpNotFound();
            }
            ViewBag.NAT_MARCH_ID = new SelectList(db.NatureMarchandises, "NAT_MARCH_ID", "NAT_MARCH_LIBELLE", marchandise.NAT_MARCH_ID);
            return View(marchandise);
        }

        // POST: Marchandises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MARCH_ID,NAT_MARCH_ID,MARCH_DESC,MARCH_PDS,MARCH_QTE,MARCH_TYPE,MARCH_VALEURO,MARCH_DOUANE,MARCH_OBS")] Marchandise marchandise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marchandise).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NAT_MARCH_ID = new SelectList(db.NatureMarchandises, "NAT_MARCH_ID", "NAT_MARCH_LIBELLE", marchandise.NAT_MARCH_ID);
            return View(marchandise);
        }

        // GET: Marchandises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchandise marchandise = await db.Marchandises.FindAsync(id);
            if (marchandise == null)
            {
                return HttpNotFound();
            }
            return View(marchandise);
        }

        // POST: Marchandises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Marchandise marchandise = await db.Marchandises.FindAsync(id);
            db.Marchandises.Remove(marchandise);
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
