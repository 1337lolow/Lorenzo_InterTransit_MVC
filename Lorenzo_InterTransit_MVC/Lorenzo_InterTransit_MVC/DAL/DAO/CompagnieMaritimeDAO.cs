using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class CompagnieMaritimeDAO
    {
        private static InterTransit db = new InterTransit();
        public static List<CompagnieMaritime> getCMByIdDoss(string id)
        {
            var cmList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join cm in db.CompagnieMaritimes on bk.CM_REF equals cm.CM_REF
                          where ppl.FCL_ID == id
                          select cm).ToList();
            return cmList;
        }
    }
}
