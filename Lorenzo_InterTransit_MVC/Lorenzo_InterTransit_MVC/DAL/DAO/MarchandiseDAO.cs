using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class MarchandiseDAO
    {
        private static InterTransit db = new InterTransit();
        public static List<Marchandise> getMarchandiseByIdDoss(string id)
        {
            List<Marchandise> lstMarch = new List<Marchandise>();
            List<Conteneur> ctList = new List<Conteneur>();
            ctList = ConteneurDAO.getAllTCByIdDoss(id);

            
                foreach (Marchandise m in ctList.Single().Marchandises)
                {
                    lstMarch.Add(m);
                }
            
            return lstMarch;
        }
    }
}
