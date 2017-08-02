using BLL;
using Lorenzo_InterTransit_MVC.DAL;
using Lorenzo_InterTransit_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lorenzo_InterTransit_MVC.Controllers
{
    public class HomeController : Controller
    {
        private InterTransit db = new InterTransit();
        ClientManager cli = new ClientManager();
        TransporteurManager trsMgr = new TransporteurManager();
        CompagnieMaritimeManager cieMar = new CompagnieMaritimeManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Repertoire(int? IdClient, int? idTrans, int? idCieMari)
        {
            var viewModel = new RepertoireVM();
            if(IdClient != null)
            {
                viewModel.clientRepertoire = cli.GetAllClient();
                return View(viewModel);
            }
            if (idTrans != null)
            {
                viewModel.transRepertoire = trsMgr.GetAllTrans();
                return View(viewModel);
            }
            if (idCieMari != null)
            {
                viewModel.cieMaritimeRepertoire = cieMar.GetAllCieMaritime();
                return View(viewModel);
            }
            viewModel.cieMaritimeRepertoire = cieMar.GetAllCieMaritime();
            viewModel.clientRepertoire = cli.GetAllClient();
            viewModel.transRepertoire = trsMgr.GetAllTrans();


            return View(viewModel);
        }
        public ActionResult RepertoireCieMari()
        {
            var viewModel = new RepertoireVM();
            viewModel.cieMaritimeRepertoire = cieMar.GetAllCieMaritime();
            return View(viewModel);
        }
        public ActionResult RepertoireTrans()
        {
            var viewModel = new RepertoireVM();
            viewModel.transRepertoire = trsMgr.GetAllTrans();
            return View(viewModel);
        }
        public ActionResult RepertoireClient()
        {
            var viewModel = new RepertoireVM();
            viewModel.clientRepertoire = cli.GetAllClient();
            return View(viewModel);
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