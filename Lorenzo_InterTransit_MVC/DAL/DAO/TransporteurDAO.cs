using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class TransporteurDAO
    {
        private  InterTransit db = new InterTransit();
        public  List<Transporteur> GetTransporteurByIdDoss(string id)
        {
            var transList = (from ppl in db.DossierFclExports
                             join it in db.InstruTransporteurs on id equals it.FCL_ID
                             join tr in db.Transporteurs on it.TRS_REF equals tr.TRS_REF
                             where ppl.FCL_ID == id
                             select tr).ToList();
            return transList;
        }

        public List<Transporteur> GetAllTransporteur()
        {
            var allTrans = (from ppl in db.Transporteurs select ppl).ToList();
            return allTrans;
        }
    }
}
