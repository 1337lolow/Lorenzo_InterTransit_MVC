using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransporteurManager
    {
        private TransporteurDAO lesTrans = new TransporteurDAO();
        public List<Transporteur> GetTransByIdDoss(string id)
        {
           return lesTrans.GetTransporteurByIdDoss(id);
        }

        public int numTransCompteur()
        {
           return (lesTrans.GetAllTransporteur().Count+1);
        }

        public IEnumerable<Transporteur> GetAllTrans()
        {
            return lesTrans.GetAllTransporteur();
        }
    }
}
