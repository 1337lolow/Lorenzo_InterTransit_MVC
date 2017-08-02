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
    public class BookingsController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: Bookings
        public async Task<ActionResult> Index()
        {
            var bookings = db.Bookings.Include(b => b.CompagnieMaritime).Include(b => b.DossierFclExport);
            return View(await bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.CM_REF = new SelectList(db.CompagnieMaritimes, "CM_REF", "CM_NOMRAIS");
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BKG_NUM,FCL_ID,CM_REF,BKG_NOMNAVIRE,BKG_DATE,BKG_ETA,BKG_ETD,BKG_FORWARDER,BKG_LOADTERM,BKG_NUMVYG,BKG_PORTARRIVEE,BKG_PORTDEPART,BKG_PORTFORWARDER,BKG_REFCOTATION,BKG_OBS,BKG_REFBL")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CM_REF = new SelectList(db.CompagnieMaritimes, "CM_REF", "CM_NOMRAIS", booking.CM_REF);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", booking.FCL_ID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CM_REF = new SelectList(db.CompagnieMaritimes, "CM_REF", "CM_NOMRAIS", booking.CM_REF);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", booking.FCL_ID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BKG_NUM,FCL_ID,CM_REF,BKG_NOMNAVIRE,BKG_DATE,BKG_ETA,BKG_ETD,BKG_FORWARDER,BKG_LOADTERM,BKG_NUMVYG,BKG_PORTARRIVEE,BKG_PORTDEPART,BKG_PORTFORWARDER,BKG_REFCOTATION,BKG_OBS,BKG_REFBL")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CM_REF = new SelectList(db.CompagnieMaritimes, "CM_REF", "CM_NOMRAIS", booking.CM_REF);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", booking.FCL_ID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Booking booking = await db.Bookings.FindAsync(id);
            db.Bookings.Remove(booking);
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
