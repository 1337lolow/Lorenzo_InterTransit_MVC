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
using BLL.ViewModels;
using System.Data.Entity.Infrastructure;
using BLL;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    /// <summary>
    /// class controller de Conteneur
    /// </summary>
    public class ConteneursController : Controller
    {
        private InterTransit db = new InterTransit();
        private ConteneursManager tcMgr = new ConteneursManager();

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
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "BKG_NUM");
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE");
            return View();
        }

        // POST: Conteneurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CTN_REF,TYTC_ID,BKG_NUM,CTN_PLOMBAGE,CTN_DATEPLOMBAGE,CTN_REFCOX,CTN_OBS")] Conteneur conteneur, string[] selectedMarch)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Conteneurs.Add(conteneur);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", new { Controller = "DossierFclExports", id = tcMgr.getFclIdFromTC(conteneur.BKG_ID).ToString() });
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }

            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "BKG_NUM", conteneur.BKG_ID);
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
            Conteneur conteneur =  db.Conteneurs.Include(p => p.Marchandises).Where(i => i.CTN_REF == id).Single();
            if (conteneur == null)
            {
                return HttpNotFound();
            }
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "BKG_NUM", conteneur.BKG_ID);
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE", conteneur.TYTC_ID);
            PopulateAssignedData(conteneur);
            return View(conteneur);
        }

        // POST: Conteneurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Méthode d'edition du Conteneur, et eprmet aussi de lier la marchandise au TC
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selectedMarch"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedMarch)
        //public async Task<ActionResult> Edit([Bind(Include = "CTN_REF,TYTC_ID,BKG_NUM,CTN_PLOMBAGE,CTN_DATEPLOMBAGE,CTN_REFCOX,CTN_OBS")] Conteneur conteneur, string[] selectedMarch)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var TCToUpdate = db.Conteneurs.Include(p => p.Marchandises).Where(i => i.CTN_REF == id).Single();

            if(TryUpdateModel(TCToUpdate, "", new string[] { "CTN_REF","TYTC_ID","BKG_NUM","CTN_PLOMBAGE","CTN_DATEPLOMBAGE","CTN_REFCOX","CTN_OBS" }))
            {
                try
                {

                    UpdateTCMarch(selectedMarch, TCToUpdate);

                    db.Entry(TCToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { Controller = "DossierFclExports", id = tcMgr.getFclIdFromTC(TCToUpdate.BKG_ID) });

                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "pas capable de sauvegarder les changements, better call lolow");
                }
            }
            
            ViewBag.BKG_NUM = new SelectList(db.Bookings, "BKG_NUM", "BKG_NUM", TCToUpdate.BKG_ID);
            ViewBag.TYTC_ID = new SelectList(db.TypeTCs, "TYTC_ID", "TYTC_TYPE", TCToUpdate.TYTC_ID);
            return View(TCToUpdate);
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
            string idFcl = tcMgr.getFclIdFromTC(conteneur.BKG_ID);
            db.Conteneurs.Remove(conteneur);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { Controller = "DossierFclExports", id = idFcl });

        }
        /// <summary>
        /// méthode complémentaire à la liaison des marchandises au TC
        /// </summary>
        /// <param name="selectedMarch"></param>
        /// <param name="tcToUpdate"></param>
        private void UpdateTCMarch (string[] selectedMarch, Conteneur tcToUpdate)
        {
            if (selectedMarch == null)
            {
                tcToUpdate.Marchandises = new List<Marchandise>();
                return;
            }
            var selectedMarchMS = new HashSet<string>(selectedMarch);
            var tcMarchy = new HashSet<int>(tcToUpdate.Marchandises.Select(b => b.MARCH_ID));
            foreach(var march in db.Marchandises)
            {
                if (selectedMarchMS.Contains(march.MARCH_ID.ToString()))
                {
                    if (!tcMarchy.Contains(march.MARCH_ID))
                    {
                        tcToUpdate.Marchandises.Add(march);
                    }
                }
                else
                {
                    if (tcMarchy.Contains(march.MARCH_ID))
                    {
                        tcToUpdate.Marchandises.Remove(march);
                    }
                }
            }
        }

        private void PopulateAssignedData(Conteneur tc)
        {
            var allMarchandise = db.Marchandises;
            var conteneurMarchandise = new HashSet<int>(tc.Marchandises.Select(b => b.MARCH_ID));
            var viewModel = new List<MarchConteneurVM>();
            

            foreach(var march in allMarchandise)
            {
                viewModel.Add(new MarchConteneurVM {
                    marchID = march.MARCH_ID,
                    marchName = march.MARCH_DESC,
                    Assigned = conteneurMarchandise.Contains(march.MARCH_ID)
                    
                });
            }
            ViewBag.March = viewModel;
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
