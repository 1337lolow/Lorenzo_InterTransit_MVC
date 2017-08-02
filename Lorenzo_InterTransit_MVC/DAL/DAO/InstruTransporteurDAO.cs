using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class InstruTransporteurDAO
    {
        private  InterTransit db = new InterTransit();

        public  List<InstruTransporteur> getInstruTransByIdDoss(string id)
        {
            var lstTrans = (from ppl in db.InstruTransporteurs
                           where ppl.FCL_ID == id
                           select ppl).ToList();
            return lstTrans;
        }
    }
}
