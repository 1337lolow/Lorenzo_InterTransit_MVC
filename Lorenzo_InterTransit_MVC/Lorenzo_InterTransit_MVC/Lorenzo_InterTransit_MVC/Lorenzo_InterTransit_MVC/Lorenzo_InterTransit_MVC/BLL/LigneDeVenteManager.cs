using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LigneDeVenteManager
    {
        LigneDeVenteDAO ldvDao = new LigneDeVenteDAO();

        public List<LigneDeVente> GetLigneDeVenteByIdDoss(string id)
        {
            return ldvDao.getLigneVenteByIdDoss(id);
        }

        public List<LigneDeVente> GetLVByIdDevi(int id)
        {
            return ldvDao.GetLVByIdDevi(id);
        }
    }
}
