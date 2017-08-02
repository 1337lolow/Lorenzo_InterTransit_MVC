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
    /// classe DAo du dossier FCL
    /// </summary>
    public class DossierFclDAO
    {
        private  InterTransit db = new InterTransit();

        /// <summary>
        /// methode permettant d'obtenir les dossiers en fonction de l'id dossier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DossierFclExport> getDossByID (string id)
        {
            var doss = (from ppl in db.DossierFclExports
                        where ppl.FCL_ID == id
                        select ppl).ToList();
            return doss;
        }

        /// <summary>
        /// methode permettant d'obtenir tout les dossiers fcl
        /// </summary>
        /// <returns></returns>
        public List<DossierFclExport> GetAllDoss()
        {
            var allDoss = (from ppl in db.DossierFclExports select ppl).ToList();
            return allDoss;
        }

        /// <summary>
        /// methode permettant de rechercher les dossier en fonction de l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DossierFclExport> searchDossById(string id)
        {
            List<DossierFclExport> leDoss = new List<DossierFclExport>();
             leDoss = (from ppl in db.DossierFclExports
                          where ppl.FCL_ID.Contains(id)
                          select ppl).ToList();
            return leDoss;
        }

        /// <summary>
        /// methode permettant d'ajouter le dossier Fcl à la BDD
        /// </summary>
        /// <param name="leDossAdd"></param>
        public void AddDoss(DossierFclExport leDossAdd)
        {
            db.DossierFclExports.Add(leDossAdd);
            db.SaveChanges();
        }


    }
}
