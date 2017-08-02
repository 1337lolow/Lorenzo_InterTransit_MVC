using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// classe manager de dossier fcl
    /// </summary>
    public class DossierFclManager
    {
        private DossierFclDAO leDoss = new DossierFclDAO();

        /// <summary>
        /// methode permettant d'obtenir une liste de dossier en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DossierFclExport> GetDossById(string id)
        {
            return leDoss.getDossByID(id);
        }

        /// <summary>
        /// methode permettant d'obtenir tout les dossiers 
        /// </summary>
        /// <returns></returns>
        public List<DossierFclExport> GetAllDoss()
        {
            return leDoss.GetAllDoss();
        }
        /// <summary>
        /// methode permettant d'obtenir les dossiers fcl grace à la barre de recherche
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DossierFclExport> searchDossById(string id)
        {
            return leDoss.searchDossById(id);
        }

        /// <summary>
        /// methode permettant d'obtenir un new id dossier fcl
        /// </summary>
        /// <returns></returns>
        public int numDossCompteur()
        {
            List<int> lstNum = new List<int>();
            int jin;
            var lastDoss = (from ppl in GetAllDoss()
                            select ppl).ToList();
            if (lastDoss.Count == 0)
            {
                jin = 1;
            }
            else
            {
                foreach (DossierFclExport doss in lastDoss)
                {
                    int x = Convert.ToInt32(doss.FCL_ID.Substring(5, (doss.FCL_ID.Length) - 5));
                    lstNum.Add(x);
                }
                jin = (from ppl in lstNum
                       select ppl).Max();
                jin++;
            }
            return jin;
        }
        /// <summary>
        /// methode permettant d'ajouter un dossier fcl à la bdd
        /// </summary>
        /// <param name="leDossAdd"></param>
        public void AddDossier(DossierFclExport leDossAdd)
        {
            leDoss.AddDoss(leDossAdd);
        }


    }
}
