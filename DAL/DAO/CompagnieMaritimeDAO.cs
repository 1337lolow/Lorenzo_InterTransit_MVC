using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.Net;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace DAL.DAO
{
    /// <summary>
    /// classe de DAO compagnie maritime
    /// </summary>
    public class CompagnieMaritimeDAO 
    {
        private  InterTransit db = new InterTransit();
        /// <summary>
        /// methode permettant d'obtenir les compagnie maritimes en fonction de l'id dossier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CompagnieMaritime> getCMByIdDoss(string id)
        {
            var cmList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join cm in db.CompagnieMaritimes on bk.CM_REF equals cm.CM_REF
                          where ppl.FCL_ID == id
                          select cm).ToList();
            return cmList;
        }

        /// <summary>
        /// methode permettant d'ajouter une compagnie maritime à la BDD
        /// </summary>
        /// <param name="rezCompa"></param>
        public void AddCM(CompagnieMaritime rezCompa)
        {
            db.CompagnieMaritimes.Add(rezCompa);
            db.SaveChanges();
        }

        /// <summary>
        /// methode permettant d'obtenir toute les compagnie maritimes
        /// </summary>
        /// <returns></returns>
        public List<CompagnieMaritime> GetAllCompMaritime()
        {

                var allComp = (from ppl in db.CompagnieMaritimes select ppl).ToList();
                return allComp;

         
        }
    }
}
