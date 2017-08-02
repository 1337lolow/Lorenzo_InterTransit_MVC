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
    /// Classe manager de client, elle est essentiellement en interaction avec la DAO client et les controller
    /// </summary>
    public class ClientManager
    {
        ClientDAO cliDao = new ClientDAO();

        /// <summary>
        /// methode qui renvoi une liste de client en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Client> GetClientByIdDoss(string id)
        {
            return cliDao.getClientByIDDoss(id);
        }
        public void AddClient (Client cli)
        {
            cliDao.AddClient(cli);
        }

        /// <summary>
        /// méthode qui renvoi le client lié au devi en fonction de l'id devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client GetClientByIdDevi(int id)
        {
            return cliDao.GetClientByIdDevi(id);
        }

        /// <summary>
        /// méthode qui renvoi une liste de tout les clients de la BDD
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetAllClient()
        {
           return cliDao.GetAllClient();
        }

        /// <summary>
        /// méthode de creation d'id client
        /// </summary>
        /// <returns></returns>
        public int NewIdClient()
        {
            return cliDao.NewIdClient();
        }


    }
}
