using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.ViewModels;
using Lorenzo_InterTransit_MVC.DAL;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class ClientsController : Controller
    {
        private InterTransit db = new InterTransit();

        // GET: Clients
        public ActionResult Index(int? id, string fclid, string searchString)
        {

            var viewModel = new DossierDuClient();
            viewModel.Clients = db.Clients.Include(i => i.DossierFclExports);
            if(!String.IsNullOrEmpty(searchString))
            {
                viewModel.Clients = db.Clients.Where(s => s.CLT_NOMRAIS.ToUpper().Contains(searchString.ToUpper()));
            }
            //Affichage des dossiers du client sélectionné
            if (id != null)
            {
                ViewBag.FclID = id.Value;
                viewModel.DossierFclExports = viewModel.Clients.Where(i => i.CLT_ID == id.Value).Single().DossierFclExports;
            }

            //Affichage du résumé du dossier sélectionné
            if(!String.IsNullOrEmpty( fclid ))
            {
                ViewBag.FclID = fclid.ToString();
                viewModel.InstruTransporteurs = viewModel.DossierFclExports.Where(x => x.FCL_ID == fclid.ToString()).Single().InstruTransporteurs;
                viewModel.Bookings = viewModel.DossierFclExports.Where(x => x.FCL_ID == fclid.ToString()).Single().Bookings;
            }
            return View(viewModel);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLT_ID,CLT_REF,CLT_NOMRAIS,CLT_SIRET,CLT_ADRESSE,CLT_CP,CLT_VILLE,CLT_PAYS,CLT_MAIL,CLT_TEL,CLT_TELPORT,CLT_FAX,CLT_OBS")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLT_ID,CLT_REF,CLT_NOMRAIS,CLT_SIRET,CLT_ADRESSE,CLT_CP,CLT_VILLE,CLT_PAYS,CLT_MAIL,CLT_TEL,CLT_TELPORT,CLT_FAX,CLT_OBS")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
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
