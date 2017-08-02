using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DevisManager
    {
        DevisDAO devis = new DevisDAO();
        
        public List<Devi> getDevisByIDDoss(string id, List<LigneDeVente> lstLV)
        {
            return devis.getDevisByIdDoss(id, lstLV);
        }
        public string getIdFclFromLV(int ligneId)
        {
          return  devis.getFclIdFromLV(ligneId);
        }
        public Devi GetDeviById(int id)
        {
            return devis.FindDevisById(id);
        }

        public int IdDevisCompteur()
        {
            return (devis.GetAllDevis().Count+1);
        }
    }
}
