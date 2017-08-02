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
    public class LigneDeVentesController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: LigneDeVentes
        public async Task<ActionResult> Index()
        {
            var ligneDeVentes = db.LigneDeVentes.Include(l => l.Devi).Include(l => l.DossierFclExport);
            return View(await ligneDeVentes.ToListAsync());
        }

        // GET: LigneDeVentes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneDeVente ligneDeVente = await db.LigneDeVentes.FindAsync(id);
            if (ligneDeVente == null)
            {
                return HttpNotFound();
            }
            return View(ligneDeVente);
        }

        // GET: LigneDeVentes/Create
        public ActionResult Create()
        {
            ViewBag.DEVIS_ID = new SelectList(db.Devis, "DEVIS_ID", "DEVIS_REF_FORM");
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID");
            return View();
        }

        // POST: LigneDeVentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ACHVNT_ID,FCL_ID,DEVIS_ID,ACHVNT_DESC_ACHAT,ACHVNT_DESC_VENTE,ACHVNT_NAT_ACHAT,ACHVNT_PRIX_ACHAT,ACHVNT_PRIX_VENTE,ACHVNT_OBS")] LigneDeVente ligneDeVente)
        {
            if (ModelState.IsValid)
            {
                db.LigneDeVentes.Add(ligneDeVente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DEVIS_ID = new SelectList(db.Devis, "DEVIS_ID", "DEVIS_REF_FORM", ligneDeVente.DEVIS_ID);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", ligneDeVente.FCL_ID);
            return View(ligneDeVente);
        }

        // GET: LigneDeVentes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneDeVente ligneDeVente = await db.LigneDeVentes.FindAsync(id);
            if (ligneDeVente == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEVIS_ID = new SelectList(db.Devis, "DEVIS_ID", "DEVIS_REF_FORM", ligneDeVente.DEVIS_ID);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", ligneDeVente.FCL_ID);
            return View(ligneDeVente);
        }

        // POST: LigneDeVentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ACHVNT_ID,FCL_ID,DEVIS_ID,ACHVNT_DESC_ACHAT,ACHVNT_DESC_VENTE,ACHVNT_NAT_ACHAT,ACHVNT_PRIX_ACHAT,ACHVNT_PRIX_VENTE,ACHVNT_OBS")] LigneDeVente ligneDeVente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligneDeVente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DEVIS_ID = new SelectList(db.Devis, "DEVIS_ID", "DEVIS_REF_FORM", ligneDeVente.DEVIS_ID);
            ViewBag.FCL_ID = new SelectList(db.DossierFclExports, "FCL_ID", "FCL_ID", ligneDeVente.FCL_ID);
            return View(ligneDeVente);
        }

        // GET: LigneDeVentes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneDeVente ligneDeVente = await db.LigneDeVentes.FindAsync(id);
            if (ligneDeVente == null)
            {
                return HttpNotFound();
            }
            return View(ligneDeVente);
        }

        // POST: LigneDeVentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LigneDeVente ligneDeVente = await db.LigneDeVentes.FindAsync(id);
            db.LigneDeVentes.Remove(ligneDeVente);
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
