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
        
        public  static int getIdDevis(string id)
        {

            int idDevis = (from ppl in LigneDeVenteDAO.getLigneVenteByIdDoss(id)
                           select ppl.Devi.DEVIS_ID).FirstOrDefault();

            return idDevis;
        }

        public List<Devi> getDevisByIdDoss(string id)
        {
            var idDevis = getIdDevis(id);
            var devisDetail = (from ppl in db.Devis
                               where ppl.DEVIS_ID == idDevis
                               select ppl).ToList();
            return devisDetail;
        }
    }
}
