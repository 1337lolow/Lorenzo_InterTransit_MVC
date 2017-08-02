using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompagnieMaritimeManager
    {
        private CompagnieMaritimeDAO cmDao = new CompagnieMaritimeDAO();

        public List<CompagnieMaritime> GetCMByIdDoss(string id)
        {
            return cmDao.getCMByIdDoss(id);
        }

        public int numCompMaritime()
        {
            return (cmDao.GetAllCompMaritime().Count + 1);
        }
    }
}
