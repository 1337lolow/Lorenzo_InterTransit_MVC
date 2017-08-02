using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// classe manager de conteneurs
    /// </summary>
    public class ConteneursManager
    {
        ConteneurDAO leTC = new ConteneurDAO();


        /// <summary>
        /// methode permettant d'obtenir le num dossier fcl en fonction du numero de booking
        /// </summary>
        /// <param name="bkgNum"></param>
        /// <returns></returns>
        public string getFclIdFromTC ( int? bkgNum)
        {
            return leTC.getFclIdFromTC(bkgNum);
        }

        /// <summary>
        /// methode permettant d'obtenir tout les TC du dossier fcl en fonction de l'id dossier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Conteneur> getAllTCByIdDoss(string id)
        {
            return leTC.getAllTCByIdDoss(id);
        }
    }
}
