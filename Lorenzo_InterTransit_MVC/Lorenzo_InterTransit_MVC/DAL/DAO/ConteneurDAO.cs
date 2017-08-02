using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ConteneurDAO
    {
        private static InterTransit db = new InterTransit();

        public static List<Conteneur> getAllTCByIdDoss(string id)
        {
            var ctList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join ct in db.Conteneurs on bk.BKG_NUM equals ct.BKG_NUM
                          where ppl.FCL_ID == id
                          select ct).ToList();
            return ctList;
        }
    }
}
