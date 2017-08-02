using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientManager
    {
        ClientDAO cliDao = new ClientDAO();
        public List<Client> GetClientByIdDoss(string id)
        {
            return cliDao.getClientByIDDoss(id);
        }

        public Client GetClientByIdDevi(int id)
        {
            return cliDao.GetClientByIdDevi(id);
        }
    }
}
