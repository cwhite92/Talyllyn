using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int FareId { get; set; }

        public int? DiscountId { get; set; }

        public int TimetableId { get; set; }

        public bool Wheelchair { get; set; }

        public virtual Fare Fare { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual Timetable Timetable { get; set; }
    }
}