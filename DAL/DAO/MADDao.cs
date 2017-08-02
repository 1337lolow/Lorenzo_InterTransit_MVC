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
    /// classe DAO de Mise à disposition (=MAD)
    /// </summary>
    public class MADDao
    {
        private  InterTransit db = new InterTransit();
        /// <summary>
        /// methode permettant d'obtenir la MAD en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MAD> getMADByIdDoss(string id)
        {
            var madList = (from ppl in db.DossierFclExports
                           join it in db.InstruTransporteurs on id equals it.FCL_ID
                           join md in db.MADs on it.MAD_ID equals md.MAD_ID
                           where ppl.FCL_ID == id
                           select md).ToList();
            return madList;
        }

        /// <summary>
        /// methode permettant d'obtenir toute les MAD
        /// </summary>
        /// <returns></returns>
        public List<MAD> GetAllMad()
        {
            var madList = (from ppl in db.MADs
                           select ppl).ToList();
            return madList;
        }

        /// <summary>
        /// methode permettant d'ajouter une MAD à la BDD
        /// </summary>
        /// <param name="rezMad"></param>
        public void AddMad(MAD rezMad)
        {
            db.MADs.Add(rezMad);
            db.SaveChanges();
        }
    }
}
