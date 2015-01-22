using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, Display(Name = "Fare")]
        public int FareId { get; set; }

        [Display(Name = "Discount?")]
        public int? DiscountId { get; set; }

        [Required, Display(Name = "Date of Travel")]
        public int TimetableId { get; set; }

        [Required, Display(Name = "Wheelchair space required?")]
        public bool Wheelchair { get; set; }

        public virtual Fare Fare { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual Timetable Timetable { get; set; }
    }
}