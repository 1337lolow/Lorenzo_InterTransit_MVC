using DAL.DAO;
using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingManager
    {
        private BookingDAO bkdao = new BookingDAO();
        public List<Booking> getBookingByIdDoss(string id)
        {
            return bkdao.getBookingByIdDoss(id);
        }
    }
}
