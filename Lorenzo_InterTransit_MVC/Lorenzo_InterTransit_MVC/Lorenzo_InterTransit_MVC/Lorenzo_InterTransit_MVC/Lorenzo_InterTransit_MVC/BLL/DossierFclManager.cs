using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DossierFclManager
    {
        private DossierFclDAO leDoss = new DossierFclDAO();

        public List<DossierFclExport> GetDossById(string id)
        {
            return leDoss.getDossByID(id);
        }
        public List<DossierFclExport> GetAllDoss()
        {
            return leDoss.GetAllDoss();
        }
        public List<DossierFclExport> searchDossById(string id)
        {
            return leDoss.searchDossById(id);
        }
        public int numDossCompteur()
        {
            List<int> lstNum = new List<int>();
            int jin;
            var lastDoss = (from ppl in GetAllDoss()
                            select ppl).ToList();
            if (lastDoss.Count == 0)
            {
                jin = 1;
            }
            else
            {
                foreach (DossierFclExport doss in lastDoss)
                {
                    int x = Convert.ToInt32(doss.FCL_ID.Substring(5, (doss.FCL_ID.Length) - 5));
                    lstNum.Add(x);
                }
                jin = (from ppl in lstNum
                       select ppl).Max();
                jin++;
            }
            return jin;
        }
    }
}
