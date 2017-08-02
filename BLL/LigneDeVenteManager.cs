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
    /// classe de manager de ligne de vente
    /// </summary>
    public class LigneDeVenteManager
    {
        LigneDeVenteDAO ldvDao = new LigneDeVenteDAO();

        /// <summary>
        /// methode permettant d'obtenir les lignes de ventes en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LigneDeVente> GetLigneDeVenteByIdDoss(string id)
        {
            return ldvDao.getLigneVenteByIdDoss(id);
        }

        /// <summary>
        /// methode permettant d'obtenir les lignes de ventes en fonction de l'id Devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LigneDeVente> GetLVByIdDevi(int id)
        {
            return ldvDao.GetLVByIdDevi(id);
        }
    }
}
