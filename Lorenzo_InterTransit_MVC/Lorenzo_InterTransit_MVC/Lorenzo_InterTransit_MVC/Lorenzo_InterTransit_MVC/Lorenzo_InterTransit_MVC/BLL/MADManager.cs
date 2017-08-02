using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MADManager
    {
        MADDao madDao = new MADDao();
        public List<MAD> GetMadByIdDoss (string id)
        {
            return madDao.getMADByIdDoss(id);
        }
    }
}
