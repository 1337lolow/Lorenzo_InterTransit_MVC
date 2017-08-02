using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ClientDAO
    {
        private InterTransit db = new InterTransit();
        public List<Client> getClientByIDDoss(string id)
        {
            var cli = (from ppl in db.DossierFclExports
                       join cl in db.Clients on ppl.CLT_ID equals cl.CLT_ID
                       where ppl.FCL_ID == id
                       select cl).ToList();
            return cli;
        }

        public Client GetClientByIdDevi(int id)
        {
            Client leClient = (from ppl in db.Devis
                               join lv in db.LigneDeVentes on ppl.DEVIS_ID equals lv.DEVIS_ID
                               join dos in db.DossierFclExports on lv.FCL_ID equals dos.FCL_ID
                               join cli in db.Clients on dos.CLT_ID equals cli.CLT_ID
                               select cli).FirstOrDefault();
            return leClient;
        }
    }
}
