using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Classe manager de booking
    /// </summary>
    public class BookingManager
    {
        private BookingDAO bkdao = new BookingDAO();

        /// <summary>
        /// méthode appelant la méthode de DAO qui retourne les booking en fonction de l'id dossier Fcl
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Booking> getBookingByIdDoss(string id)
        {
            return bkdao.getBookingByIdDoss(id);
        }

        /// <summary>
        /// méthode qui sert à créer un Id booking 
        /// </summary>
        /// <returns></returns>
        public int CompteurNumBkg()
        {
            return ((bkdao.GetAllBooking().Count) + 1);
        }

        /// <summary>
        /// méthode qui prend en parametre un objet booking et qui l'envoi à la DAO booking pour l'insertion dans la BDD d'un booking
        /// </summary>
        /// <param name="rezBkg"></param>
        public void AddBooking(Booking rezBkg)
        {
            bkdao.AddBooking(rezBkg);
        }

    }
}

