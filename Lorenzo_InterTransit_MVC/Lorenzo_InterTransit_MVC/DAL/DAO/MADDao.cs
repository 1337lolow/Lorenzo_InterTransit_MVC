using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class MADDao
    {
        private static InterTransit db = new InterTransit();
        public static List<MAD> getMADByIdDoss(string id)
        {
            var madList = (from ppl in db.DossierFclExports
                           join it in db.InstruTransporteurs on id equals it.FCL_ID
                           join md in db.MADs on it.MAD_ID equals md.MAD_ID
                           where ppl.FCL_ID == id
                           select md).ToList();
            return madList;
        }
    }
}
