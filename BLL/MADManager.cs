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
        /// <summary>
        /// classe manager de Mise à disposition = MAD
        /// </summary>
        MADDao madDao = new MADDao();

        /// <summary>
        /// methode permettant d'obtenir la MAD en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MAD> GetMadByIdDoss (string id)
        {
            return madDao.getMADByIdDoss(id);
        }

        /// <summary>
        /// methode permettant d'ajouter une MAD à la BDD
        /// </summary>
        /// <param name="rezMad"></param>
        public void AddMad(MAD rezMad)
        {
            madDao.AddMad(rezMad);
        }

        /// <summary>
        /// methode permettant d'obtenir un new id MAD
        /// </summary>
        /// <returns></returns>
        public string NumMad()
        {

            var numMad = madDao.GetAllMad();
            string madId;
            if(numMad.Count == 0)
            {
                madId = "1";
            }
            else
            {
                madId = (numMad.Count+1).ToString();
            }
            return madId;
        }
    }
}
