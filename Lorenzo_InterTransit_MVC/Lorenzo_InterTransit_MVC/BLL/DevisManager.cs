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
        
        public List<Devi> getDevisByIDDoss(string id)
        {
            return devis.getDevisByIdDoss(id);
        }
    }
}
