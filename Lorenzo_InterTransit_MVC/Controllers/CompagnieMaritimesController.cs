﻿using System;
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
using System.Data.Entity.Infrastructure;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    /// <summary>
    /// class controller de  Compagnie maritime
    /// </summary>
    public class CompagnieMaritimesController : Controller
    {
        private InterTransit db = new InterTransit();
        private CompagnieMaritimeManager cmMgr = new CompagnieMaritimeManager();

        // GET: CompagnieMaritimes
        public async Task<ActionResult> Index()
        {
            return View(await db.CompagnieMaritimes.ToListAsync());
        }

        // GET: CompagnieMaritimes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompagnieMaritime compagnieMaritime = await db.CompagnieMaritimes.FindAsync(id);
            if (compagnieMaritime == null)
            {
                return HttpNotFound();
            }
            return View(compagnieMaritime);
        }

        // GET: CompagnieMaritimes/Create
        public ActionResult Create()
        {
            ViewBag.iDCompMari = cmMgr.numCompMaritime();
            return View();
        }

        // POST: CompagnieMaritimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CM_REF,CM_NOMRAIS,CM_SIRET,CM_ADRESSE,CM_CP,CM_VILLE,CM_PAYS,CM_MAIL,CM_TEL,CM_TELPORT,CM_FAX,CM_OBS")] CompagnieMaritime compagnieMaritime)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.CompagnieMaritimes.Add(compagnieMaritime);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return View(compagnieMaritime);
        }

        // GET: CompagnieMaritimes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompagnieMaritime compagnieMaritime = await db.CompagnieMaritimes.FindAsync(id);
            if (compagnieMaritime == null)
            {
                return HttpNotFound();
            }
            return View(compagnieMaritime);
        }

        // POST: CompagnieMaritimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CM_REF,CM_NOMRAIS,CM_SIRET,CM_ADRESSE,CM_CP,CM_VILLE,CM_PAYS,CM_MAIL,CM_TEL,CM_TELPORT,CM_FAX,CM_OBS")] CompagnieMaritime compagnieMaritime)
        {
            
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(compagnieMaritime).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError(" ", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }
            return View(compagnieMaritime);
        }

        // GET: CompagnieMaritimes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompagnieMaritime compagnieMaritime = await db.CompagnieMaritimes.FindAsync(id);
            if (compagnieMaritime == null)
            {
                return HttpNotFound();
            }
            return View(compagnieMaritime);
        }

        // POST: CompagnieMaritimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CompagnieMaritime compagnieMaritime = await db.CompagnieMaritimes.FindAsync(id);
            db.CompagnieMaritimes.Remove(compagnieMaritime);
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
