using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class BookingDetail
    {
        public int Bookingid { get; set; }
        public int Passid { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Passenger Pass { get; set; }
    }
}
