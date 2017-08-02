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
    /// classe manager de devis
    /// </summary>
    public class DevisManager
    {
        DevisDAO devis = new DevisDAO();

        /// <summary>
        /// methode permettant d'obtenir les devis en fonction des lignes de vente et de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lstLV"></param>
        /// <returns></returns>
        public List<Devi> getDevisByIDDoss(string id, List<LigneDeVente> lstLV)
        {
            return devis.getDevisByIdDoss(id, lstLV);
        }

        /// <summary>
        /// methode permettant d'obtenir l'id fcl en fonction de l'id ligne de vente
        /// </summary>
        /// <param name="ligneId"></param>
        /// <returns></returns>
        public string getIdFclFromLV(int ligneId)
        {
          return  devis.getFclIdFromLV(ligneId);
        }

        /// <summary>
        /// methode permettant d'obtenir d'obtenir le devis en fonction de l'id devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Devi GetDeviById(int id)
        {
            return devis.FindDevisById(id);
        }

        /// <summary>
        /// methode permettant d'obtenir un nouveau id devis
        /// </summary>
        /// <returns></returns>
        public int IdDevisCompteur()
        {
            return (devis.GetAllDevis().Count+1);
        }
    }
}
