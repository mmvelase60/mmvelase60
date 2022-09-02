using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Logic
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public int countBookings(string email)
        {
            //int count = 0;

            List<Booking> app = db.Bookings.ToList().FindAll(x => x.Username.Equals(email));
            return app.Count;
        }

        public bool isFree(string email)
        {
            bool free = false;

            if (countBookings(email) >= 4)
            {
                free = true;
            }

            return free;
        }


    }
}