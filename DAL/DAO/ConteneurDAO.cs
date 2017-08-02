using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    /// <summary>
    /// classe de DAO conteneur
    /// </summary>
    public class ConteneurDAO
    {
        private  InterTransit db = new InterTransit();

        /// <summary>
        /// méthode permettant d'obtenir tout les TC du dossier en fonction de l'id dossier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  List<Conteneur> getAllTCByIdDoss(string id)
        {
            var ctList = (from ppl in db.DossierFclExports
                          join bk in db.Bookings on ppl.FCL_ID equals bk.FCL_ID
                          join ct in db.Conteneurs on bk.BKG_ID equals ct.BKG_ID
                          where ppl.FCL_ID == id
                          select ct).ToList();
            return ctList;
        }

        /// <summary>
        /// methode permettant d'obtenir l'id du dossier du conteneur
        /// </summary>
        /// <param name="bkgNum"></param>
        /// <returns></returns>
        public string getFclIdFromTC(int? bkgNum)
        {
            string idFcl = (from ppl in db.Bookings
                            join doss in db.DossierFclExports on ppl.FCL_ID equals doss.FCL_ID
                            where ppl.BKG_ID == bkgNum
                            select ppl.FCL_ID).FirstOrDefault();

            return idFcl;
        }
    }
}
