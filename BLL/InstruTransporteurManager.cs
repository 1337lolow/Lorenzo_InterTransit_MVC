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
    /// classe manager d'instruction transporteur
    /// </summary>
    public class InstruTransporteurManager
    {
        InstruTransporteurDAO instruDAO = new InstruTransporteurDAO();

        /// <summary>
        /// methode permettant d'obtenir l'instru transporteur en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<InstruTransporteur> GetInstruTransByIdDoss (string id)
        {
            return instruDAO.getInstruTransByIdDoss(id);
        }


        /// <summary>
        /// methode permettant d'obtenir un new id instruction transporteur
        /// </summary>
        /// <returns></returns>
        public int NumOffreAuto()
        {
            return instruDAO.NumOffreInstru();
        }

        /// <summary>
        /// methode permettant d'ajouter à la BDD un new instru transporteur
        /// </summary>
        /// <param name="rezInstru"></param>
        public void AddInstruTrans(InstruTransporteur rezInstru)
        {
            instruDAO.AddInstruTrans(rezInstru);
        }


    }
}
