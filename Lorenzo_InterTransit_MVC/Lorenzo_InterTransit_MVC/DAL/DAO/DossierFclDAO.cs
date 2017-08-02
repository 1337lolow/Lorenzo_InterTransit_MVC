using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DossierFclDAO
    {
        private static InterTransit db = new InterTransit();

        public static List<DossierFclExport> getDossByID (string id)
        {
            var doss = (from ppl in db.DossierFclExports
                        where ppl.FCL_ID == id
                        select ppl).ToList();
            return doss;
        }
    }
}
