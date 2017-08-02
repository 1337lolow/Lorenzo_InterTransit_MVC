using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InstruTransporteurManager
    {
        InstruTransporteurDAO instruDAO = new InstruTransporteurDAO();
        public List<InstruTransporteur> GetInstruTransByIdDoss (string id)
        {
            return instruDAO.getInstruTransByIdDoss(id);
        }
    }
}
