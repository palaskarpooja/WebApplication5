using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int Passid { get; set; }
        public string Passname { get; set; }
        public string Passemail { get; set; }
        public DateTime? Passdob { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
