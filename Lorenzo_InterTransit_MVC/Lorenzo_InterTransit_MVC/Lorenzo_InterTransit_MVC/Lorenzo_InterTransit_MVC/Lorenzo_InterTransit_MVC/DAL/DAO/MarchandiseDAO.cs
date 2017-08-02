using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class MarchandiseDAO
    {
        private InterTransit db = new InterTransit();
        public  List<Marchandise> getMarchandiseByIdDoss(string id)
        {
            ConteneurDAO leTC = new ConteneurDAO();
            List<Marchandise> lstMarch = new List<Marchandise>();
            List<Conteneur> ctList = new List<Conteneur>();
            ctList = leTC.getAllTCByIdDoss(id);

            foreach (var mc in ctList)
            {
                foreach (Marchandise m in mc.Marchandises )
                {
                    lstMarch.Add(m);
                }
            }
            return lstMarch;
        }

        public List<Marchandise> GetAllMarchandise()
        {
            var allMarch = (from ppl in db.Marchandises select ppl).ToList();
            return allMarch;
        }
    }
}
