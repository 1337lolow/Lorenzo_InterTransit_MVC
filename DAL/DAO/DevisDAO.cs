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
    /// classe de DAO de Devis
    /// </summary>
    public class DevisDAO
    {
        private InterTransit db = new InterTransit();
        
        /// <summary>
        /// methode permettant d'obtenir l'id devis en fonction de l'id fcl et des lignes de vente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lstLV"></param>
        /// <returns></returns>
        public  static int getIdDevis(string id, List<LigneDeVente> lstLV)
        {

            int idDevis = (from ppl in lstLV
                           select ppl.Devi.DEVIS_ID).FirstOrDefault();
            return idDevis;
        }

        /// <summary>
        /// methode permettant d'obtenir le devis en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lstLV"></param>
        /// <returns></returns>
        public List<Devi> getDevisByIdDoss(string id, List<LigneDeVente> lstLV)
        {
            var idDevis = getIdDevis(id, lstLV );
            var devisDetail = (from ppl in db.Devis
                               where ppl.DEVIS_ID == idDevis
                               select ppl).ToList();
            return devisDetail;
        }

        /// <summary>
        /// methode permettant d'obtenir tout les devis de la BDD
        /// </summary>
        /// <returns></returns>
        public List<Devi> GetAllDevis()
        {
            var allDevis = (from ppl in db.Devis select ppl).ToList();
            return allDevis;
        }

        /// <summary>
        /// methode permettant d'obtenir le devis en fonction de l'id devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Devi FindDevisById(int id)
        {
            return db.Devis.Find(id);
        }

        /// <summary>
        /// methode permettant d'obtenir l'id fcl en fonction de l'id devis
        /// </summary>
        /// <param name="devisId"></param>
        /// <returns></returns>
        public string getFclIdFromLV(int devisId)
        {
            string idFcl = (from ppl in db.LigneDeVentes
                            join doss in db.DossierFclExports on ppl.FCL_ID equals doss.FCL_ID
                            where ppl.DEVIS_ID == devisId
                            select ppl.FCL_ID).FirstOrDefault();

            return idFcl;
        }
    }
}
