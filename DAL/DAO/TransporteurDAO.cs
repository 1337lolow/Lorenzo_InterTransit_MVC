using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    /// <summary>
    /// classe DAO des transporteurs
    /// </summary>
    public class TransporteurDAO
    {
        private  InterTransit db = new InterTransit();

        /// <summary>
        /// methode permettant d'obtenir les transporteurs en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Transporteur> GetTransporteurByIdDoss(string id)
        {
            var transList = (from ppl in db.DossierFclExports
                             join it in db.InstruTransporteurs on id equals it.FCL_ID
                             join tr in db.Transporteurs on it.TRS_REF equals tr.TRS_REF
                             where ppl.FCL_ID == id
                             select tr).ToList();
            return transList;
        }

        /// <summary>
        /// methode permettant d'ajouter un transporteur à la BDD
        /// </summary>
        /// <param name="rezTrans"></param>
        public void AddTrans(Transporteur rezTrans)
        {
            db.Transporteurs.Add(rezTrans);
            db.SaveChanges();
        }

        /// <summary>
        /// methode permettant d'obtenir tout les transporteurs
        /// </summary>
        /// <returns></returns>
        public List<Transporteur> GetAllTransporteur()
        {
            var allTrans = (from ppl in db.Transporteurs select ppl).ToList();
            return allTrans;
        }
    }
}
