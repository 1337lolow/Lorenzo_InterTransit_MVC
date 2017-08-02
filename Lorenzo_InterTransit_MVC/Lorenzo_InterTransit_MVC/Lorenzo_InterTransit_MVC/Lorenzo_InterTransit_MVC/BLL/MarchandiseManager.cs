using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarchandiseManager
    {
        private MarchandiseDAO marchDao = new MarchandiseDAO();
        public List<Marchandise> getMarchByIdFcl(string id)
        {
            MarchandiseDAO laMarch = new MarchandiseDAO();
            return laMarch.getMarchandiseByIdDoss(id);
        }

        public int idMarchandiseCompteur()
        {
            return (marchDao.GetAllMarchandise().Count+1);
        }
    }
}
