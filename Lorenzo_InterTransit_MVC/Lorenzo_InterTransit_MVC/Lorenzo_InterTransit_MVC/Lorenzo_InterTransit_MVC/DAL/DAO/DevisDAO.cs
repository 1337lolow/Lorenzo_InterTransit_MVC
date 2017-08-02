using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DevisDAO
    {
        private InterTransit db = new InterTransit();
        
        public  static int getIdDevis(string id, List<LigneDeVente> lstLV)
        {

            int idDevis = (from ppl in lstLV
                           select ppl.Devi.DEVIS_ID).FirstOrDefault();

            return idDevis;
        }

        public List<Devi> getDevisByIdDoss(string id, List<LigneDeVente> lstLV)
        {
            var idDevis = getIdDevis(id, lstLV );
            var devisDetail = (from ppl in db.Devis
                               where ppl.DEVIS_ID == idDevis
                               select ppl).ToList();
            return devisDetail;
        }

        public List<Devi> GetAllDevis()
        {
            var allDevis = (from ppl in db.Devis select ppl).ToList();
            return allDevis;
        }

        public Devi FindDevisById(int id)
        {
            return db.Devis.Find(id);
        }

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
