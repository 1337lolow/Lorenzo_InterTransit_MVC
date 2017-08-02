using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    /// <summary>
    /// classe de DAO de ligne de ventes
    /// </summary>
    public class LigneDeVenteDAO
    {
        private  InterTransit db = new InterTransit();
        /// <summary>
        /// methode permettant d'obtenir les lignes de ventes en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LigneDeVente> getLigneVenteByIdDoss(string id)
        {
            var ligneVente = (from ppl in db.DossierFclExports
                              join lv in db.LigneDeVentes on ppl.FCL_ID equals lv.FCL_ID
                              where ppl.FCL_ID == id
                              select lv).ToList();
            return ligneVente;
        }

        /// <summary>
        /// methode permettant d'obtenir les lignes de ventes en fonction de l'id devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LigneDeVente> GetLVByIdDevi(int id)
        {
            List<LigneDeVente> lstLDV = (from ppl in db.LigneDeVentes
                                         where ppl.DEVIS_ID == id
                                         select ppl).ToList();
            return lstLDV;
        }
    }
}
