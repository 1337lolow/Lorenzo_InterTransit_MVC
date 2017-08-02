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
        private  InterTransit db = new InterTransit();

        public  List<DossierFclExport> getDossByID (string id)
        {
            var doss = (from ppl in db.DossierFclExports
                        where ppl.FCL_ID == id
                        select ppl).ToList();
            return doss;
        }

        public List<DossierFclExport> GetAllDoss()
        {
            var allDoss = (from ppl in db.DossierFclExports select ppl).ToList();
            return allDoss;
        }

        public List<DossierFclExport> searchDossById(string id)
        {
            List<DossierFclExport> leDoss = new List<DossierFclExport>();
             leDoss = (from ppl in db.DossierFclExports
                          where ppl.FCL_ID.Contains(id)
                          select ppl).ToList();
            return leDoss;
        }
    }
}
