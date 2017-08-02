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
    /// classe manager de transporteur
    /// </summary>
    public class TransporteurManager
    {
        private TransporteurDAO lesTrans = new TransporteurDAO();
        /// <summary>
        /// methode permettant d'obtenir les transpoteur en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Transporteur> GetTransByIdDoss(string id)
        {
           return lesTrans.GetTransporteurByIdDoss(id);
        }

        /// <summary>
        /// methode permettant d'obtenir un new id transporteur
        /// </summary>
        /// <returns></returns>
        public int numTransCompteur()
        {
           return (lesTrans.GetAllTransporteur().Count+1);
        }

        /// <summary>
        /// methode permettant d'obtenir tout les transporteur
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transporteur> GetAllTrans()
        {
            return lesTrans.GetAllTransporteur();
        }

        /// <summary>
        /// methode permettant d'ajouter un new transporteur à la BDD
        /// </summary>
        /// <param name="rezTrans"></param>
        public void AddTrans(Transporteur rezTrans)
        {
            lesTrans.AddTrans(rezTrans);
        }


    }
}
