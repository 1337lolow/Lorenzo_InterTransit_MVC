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
        private  InterTransit db = new InterTransit();
        public  List<CompagnieMaritime> getCMByIdDoss(string id)
        {
            var cmList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join cm in db.CompagnieMaritimes on bk.CM_REF equals cm.CM_REF
                          where ppl.FCL_ID == id
                          select cm).ToList();
            return cmList;
        }

        public List<CompagnieMaritime> GetAllCompMaritime()
        {
            var allComp = (from ppl in db.CompagnieMaritimes select ppl).ToList();
            return allComp;
        }
    }
}
