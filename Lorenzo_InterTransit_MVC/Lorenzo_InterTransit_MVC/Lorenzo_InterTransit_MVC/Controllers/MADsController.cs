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
    public class MADsController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: MADs
        public async Task<ActionResult> Index()
        {
            return View(await db.MADs.ToListAsync());
        }

        // GET: MADs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAD mAD = await db.MADs.FindAsync(id);
            if (mAD == null)
            {
                return HttpNotFound();
            }
            return View(mAD);
        }

        // GET: MADs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MADs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MAD_ID,MAD_LIEU_ENLEV,MAD_ADRES_ENLEV,MAD_DATE,MAD_OBS")] MAD mAD)
        {
            if (ModelState.IsValid)
            {
                db.MADs.Add(mAD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mAD);
        }

        // GET: MADs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAD mAD = await db.MADs.FindAsync(id);
            if (mAD == null)
            {
                return HttpNotFound();
            }
            return View(mAD);
        }

        // POST: MADs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MAD_ID,MAD_LIEU_ENLEV,MAD_ADRES_ENLEV,MAD_DATE,MAD_OBS")] MAD mAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mAD);
        }

        // GET: MADs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAD mAD = await db.MADs.FindAsync(id);
            if (mAD == null)
            {
                return HttpNotFound();
            }
            return View(mAD);
        }

        // POST: MADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MAD mAD = await db.MADs.FindAsync(id);
            db.MADs.Remove(mAD);
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
