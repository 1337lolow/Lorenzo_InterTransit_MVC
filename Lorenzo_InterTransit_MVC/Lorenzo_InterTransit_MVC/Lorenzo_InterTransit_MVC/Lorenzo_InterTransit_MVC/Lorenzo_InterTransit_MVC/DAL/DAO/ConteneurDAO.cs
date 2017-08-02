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
        private  InterTransit db = new InterTransit();

        public  List<Conteneur> getAllTCByIdDoss(string id)
        {
            var ctList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join ct in db.Conteneurs on bk.BKG_NUM equals ct.BKG_NUM
                          where ppl.FCL_ID == id
                          select ct).ToList();
            return ctList;
        }

        public string getFclIdFromTC(string bkgNum)
        {
            string idFcl = (from ppl in db.Bookings
                            join doss in db.DossierFclExports on ppl.FCL_ID equals doss.FCL_ID
                            where ppl.BKG_NUM == bkgNum
                            select ppl.FCL_ID).FirstOrDefault();

            return idFcl;
        }
    }
}
