using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int Bookingid { get; set; }
        public int? Flightid { get; set; }
        public DateTime? Bookdate { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
