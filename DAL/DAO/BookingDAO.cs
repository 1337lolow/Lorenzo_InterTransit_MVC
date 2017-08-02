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
    /// classe d'acces aux données de booking, en interraction avec la BDD
    /// </summary>
    public class BookingDAO
    {
        private  InterTransit db = new InterTransit();

        /// <summary>
        /// methode permettant d'obtenir les booking en fonction de l'id dossier fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Booking> getBookingByIdDoss(string id)
        {
            var lstBk = (from ppl in db.Bookings
                         where ppl.FCL_ID == id
                         select ppl).ToList();
            return lstBk;
        }

        /// <summary>
        /// methode permettant d'obtenir tout les bookings
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetAllBooking()
        {
            var allBkg = (from ppl in db.Bookings
                         select ppl).ToList();
            return allBkg;
        }

        /// <summary>
        /// méthode d'ajout à la BDD d'un booking
        /// </summary>
        /// <param name="rezBkg"></param>
        public void AddBooking(Booking rezBkg)
        {
            db.Bookings.Add(rezBkg);
            db.SaveChanges();
        }
    }
}
