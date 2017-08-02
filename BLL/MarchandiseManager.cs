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
        /// <summary>
        /// classe manager de marchandise
        /// </summary>
        private MarchandiseDAO marchDao = new MarchandiseDAO();

        /// <summary>
        /// methode permettant d'obtenir les marchandises en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Marchandise> getMarchByIdFcl(string id)
        {
            MarchandiseDAO laMarch = new MarchandiseDAO();
            return laMarch.getMarchandiseByIdDoss(id);
        }

        /// <summary>
        /// methode permettant d'obtenir un new Id Marchandise
        /// </summary>
        /// <returns></returns>
        public int idMarchandiseCompteur()
        {
            return (marchDao.GetAllMarchandise().Count+1);
        }
    }
}
