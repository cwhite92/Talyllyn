using SOFT331.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.ViewModels
{
    public class BaseTicketViewModel
    {
        // TODO: move this out into edit and index?
        public int Id { get; set; }

        [Display(Name = "Fare")]
        public int FareId { get; set; }
        public Fare Fare { get; set; }

        [Display(Name = "Discount")]
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }

        [Display(Name = "Date of Travel")]
        public int TimetableId { get; set; }
        public Timetable Timetable { get; set; }

        [Display(Name = "Wheelchair Space Required")]
        public bool Wheelchair { get; set; }
        public string WheelchairStatusString
        {
            get
            {
                return string.Format("{0}", this.Wheelchair ? "Yes" : "No");
            }
        }
    }

    public class TicketCreateViewModel : BaseTicketViewModel
    {
        public SelectList TimetableList { get; set; }

        public SelectList FareList { get; set; }

        public SelectList DiscountList { get; set; }
    }

    public class TicketEditViewModel : TicketCreateViewModel
    {

    }

    public class TicketIndexViewModel : BaseTicketViewModel
    {

    }

    public class TicketDeleteViewModel : BaseTicketViewModel
    {

    }
}