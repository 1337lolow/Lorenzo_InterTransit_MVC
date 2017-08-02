using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{/// <summary>
/// classe manager de compagnie maritime
/// </summary>
    public class CompagnieMaritimeManager
    {
        private CompagnieMaritimeDAO cmDao = new CompagnieMaritimeDAO();

        /// <summary>
        /// méthode permettant d'obtenir la compagnie maritime en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CompagnieMaritime> GetCMByIdDoss(string id)
        {
            return cmDao.getCMByIdDoss(id);
        }

        /// <summary>
        /// méthode de creation d'un id compagnie maritime
        /// </summary>
        /// <returns></returns>
        public int numCompMaritime()
        {
            return (cmDao.GetAllCompMaritime().Count + 1);
        }

        /// <summary>
        /// methode qui permet d'obtenir toutes les compagnies maritimes 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CompagnieMaritime> GetAllCieMaritime()
        {
            return cmDao.GetAllCompMaritime();
        }

        /// <summary>
        /// méthode d'ajout à la BDD d'une new compagnie maritime
        /// </summary>
        /// <param name="rezCompa"></param>
        public void AddCM(CompagnieMaritime rezCompa)
        {
            cmDao.AddCM(rezCompa);
        }

    }
}
