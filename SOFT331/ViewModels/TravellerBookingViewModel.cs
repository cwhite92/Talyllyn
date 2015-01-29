using SOFT331.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.ViewModels
{
    public class TravellerBookingViewModel
    {
        // List of timetables to show on homepage
        public SelectList Timetables { get; set; }

        // The timetable that gets selected on the homepage
        [Required]
        public int TimetableId { get; set; }
        public Timetable Timetable { get; set; }

        [Required, Display(Name = "Fare")]
        public int FareId { get; set; }
        public Fare Fare { get; set; }

        [Display(Name = "Discount")]
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }

        [OneWheelchairPerTrain, Display(Name = "Wheelchair Space Required?")]
        public bool Wheelchair { get; set; }

        // Filled with possible fares and discounts from database
        public SelectList FareList { get; set; }
        public SelectList DiscountList { get; set; }
    }
}