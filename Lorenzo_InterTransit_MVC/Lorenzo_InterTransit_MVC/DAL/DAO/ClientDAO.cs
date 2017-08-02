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
        private static InterTransit db = new InterTransit();
        public static List<Client> getClientByIDDoss(string id)
        {
            var cli = (from ppl in db.DossierFclExports
                       join cl in db.Clients on ppl.CLT_ID equals cl.CLT_ID
                       where ppl.FCL_ID == id
                       select cl).ToList();
            return cli;
        }
    }
}
