using Lorenzo_InterTransit_MVC;
using Lorenzo_InterTransit_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class BookingDAO
    {
        private  InterTransit db = new InterTransit();

        public  List<Booking> getBookingByIdDoss(string id)
        {
            var lstBk = (from ppl in db.Bookings
                         where ppl.FCL_ID == id
                         select ppl).ToList();
            return lstBk;
        }
    }
}
