using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Flightid { get; set; }
        public string Flightsource { get; set; }
        public string Flightdest { get; set; }
        public DateTime? Flightdate { get; set; }
        public int? Flightseat { get; set; }
        public double? Ticketcost { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
