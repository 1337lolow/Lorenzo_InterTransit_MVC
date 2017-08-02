using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class LigneDeVenteDAO
    {
        private static InterTransit db = new InterTransit();
        public static List<LigneDeVente> getLigneVenteByIdDoss(string id)
        {
            var ligneVente = (from ppl in db.DossierFclExports
                              join lv in db.LigneDeVentes on ppl.FCL_ID equals lv.FCL_ID
                              where ppl.FCL_ID == id
                              select lv).ToList();
            return ligneVente;
        }
        
    }
}
