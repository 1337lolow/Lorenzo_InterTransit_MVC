using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConteneursManager
    {
        ConteneurDAO leTC = new ConteneurDAO();

        public string getFclIdFromTC ( int? bkgNum)
        {
            return leTC.getFclIdFromTC(bkgNum);
        }

        public List<Conteneur> getAllTCByIdDoss(string id)
        {
            return leTC.getAllTCByIdDoss(id);
        }
    }
}
