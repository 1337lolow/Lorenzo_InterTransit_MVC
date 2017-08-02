using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{/// <summary>
/// classe DAO client en interraction avec la BDD
/// </summary>
    public class ClientDAO
    {
        
        private InterTransit db = new InterTransit();
        /// <summary>
        /// methode permettant d'obtenir les client du dossier fcl en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Client> getClientByIDDoss(string id)
        {
            var cli = (from ppl in db.DossierFclExports
                       join cl in db.Clients on ppl.CLT_ID equals cl.CLT_ID
                       where ppl.FCL_ID == id
                       select cl).ToList();
            return cli;
        }
        /// <summary>
        /// methode permettant d'ajouter un client à la BDD
        /// </summary>
        /// <param name="cli"></param>
        public void AddClient(Client cli)
        {
            db.Clients.Add(cli);
            db.SaveChanges();
        }
        /// <summary>
        /// méthode permettant d'obtenir tout les client de la BDD
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetAllClient()
        {
            var allCli = from ppl in db.Clients select ppl;
            return allCli;
        }


        /// <summary>
        /// methode permettant d'obtenir un new id client
        /// </summary>
        /// <returns></returns>
        public int NewIdClient()
        {
            var tracer = (from ppl in db.Clients
                          select ppl.CLT_ID);
            int newId;
            if (tracer.Count() == 0)
            {
                newId = 1;
            }
            else
            {
                newId = tracer.Max();
            }
            return newId;
        }
        /// <summary>
        /// méthode permettant d'obtenir le client en fonction de l'id devis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client GetClientByIdDevi(int id)
        {
            Client leClient = (from ppl in db.Devis
                               join lv in db.LigneDeVentes on id equals lv.DEVIS_ID
                               join dos in db.DossierFclExports on lv.FCL_ID equals dos.FCL_ID
                               join cli in db.Clients on dos.CLT_ID equals cli.CLT_ID
                               where dos.CLT_ID == cli.CLT_ID
                               select cli).FirstOrDefault();
            return leClient;
        }
    }
}
