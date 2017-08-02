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
using BLL;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class TransporteursController : Controller
    {
        private InterTransit db = new InterTransit();
        private TransporteurManager transMgr = new TransporteurManager();

        // GET: Transporteurs
        public async Task<ActionResult> Index()
        {
            var transporteurs = db.Transporteurs.Include(t => t.TypeTransporteur);
            return View(await transporteurs.ToListAsync());
        }

        // GET: Transporteurs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = await db.Transporteurs.FindAsync(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            return View(transporteur);
        }

        // GET: Transporteurs/Create
        public ActionResult Create()
        {
            ViewBag.idTrans = transMgr.numTransCompteur();
            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE");
            return View();
        }

        // POST: Transporteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TRS_REF,TYTRANS_ID,TRS_NOMRAIS,TRS_SIRET,TRS_ADRESSE,TRS_CP,TRS_VILLE,TRS_PAYS,TRS_MAIL,TRS_TEL,TRS_TELPORT,TRS_FAX,TRS_OBS")] Transporteur transporteur)
        {
            if (ModelState.IsValid)
            {
                db.Transporteurs.Add(transporteur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE", transporteur.TYTRANS_ID);
            return View(transporteur);
        }

        // GET: Transporteurs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = await db.Transporteurs.FindAsync(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE", transporteur.TYTRANS_ID);
            return View(transporteur);
        }

        // POST: Transporteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TRS_REF,TYTRANS_ID,TRS_NOMRAIS,TRS_SIRET,TRS_ADRESSE,TRS_CP,TRS_VILLE,TRS_PAYS,TRS_MAIL,TRS_TEL,TRS_TELPORT,TRS_FAX,TRS_OBS")] Transporteur transporteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporteur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TYTRANS_ID = new SelectList(db.TypeTransporteurs, "TYTRANS_ID", "TYTRANS_LIBELLE", transporteur.TYTRANS_ID);
            return View(transporteur);
        }

        // GET: Transporteurs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = await db.Transporteurs.FindAsync(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            return View(transporteur);
        }

        // POST: Transporteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Transporteur transporteur = await db.Transporteurs.FindAsync(id);
            db.Transporteurs.Remove(transporteur);
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
