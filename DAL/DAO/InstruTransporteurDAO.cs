using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    /// <summary>
    /// classe de DAO des instruction transporteur
    /// </summary>
    public class InstruTransporteurDAO
    {
        private  InterTransit db = new InterTransit();

        /// <summary>
        /// methode permettant d'obtenir les instru transporteur en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<InstruTransporteur> getInstruTransByIdDoss(string id)
        {
            var lstTrans = (from ppl in db.InstruTransporteurs
                           where ppl.FCL_ID == id
                           select ppl).ToList();
            return lstTrans;
        }

        /// <summary>
        /// methode permettant d'obtenir un new id pour les instructions transporteur
        /// </summary>
        /// <returns></returns>
        public int NumOffreInstru()
        {
            var tracer = (from ppl in db.InstruTransporteurs
                          select ppl.INSTR_NUMOFR);
            int newId;
            if (tracer.Count() == 0)
            {
                newId = 1;
            }
            else
            {
                newId = (tracer.Count())+1;
            }
            return newId;
        }

        /// <summary>
        /// methode permettant d'ajouter une instru transporteur à la BDD
        /// </summary>
        /// <param name="rezInstru"></param>
        public void AddInstruTrans(InstruTransporteur rezInstru)
        {
            db.InstruTransporteurs.Add(rezInstru);
            db.SaveChanges();
        }
    }
}
