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

        // Whether or not the traveller wishes to giftaid their ticket
        [Display(Name = "Gift Aid")]
        public bool Giftaid { get; set; }

        [RequiredWhenGiftAiding(ErrorMessage = "You must specify your name when gift aiding."), Display(Name = "Your Name"), MaxLength(50), MinLength(3)]
        public string GiftaidName { get; set; }

        [RequiredWhenGiftAiding(ErrorMessage = "You must specify your address when gift aiding."), Display(Name = "First Line of Address"), MaxLength(50), MinLength(3)]
        public string GiftaidAddressFirstLine { get; set; }

        [RequiredWhenGiftAiding(ErrorMessage = "You must specify your postcode when gift aiding."), Display(Name = "Postcode"), MaxLength(7), MinLength(5), RegularExpression(@"^(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})$")]
        public string GiftaidPostcode { get; set; }

        // If all the seats/advanced tickets on this timetable are taken, the user is unable to book
        public bool Bookable
        {
            get { return true; }
        }

        // Filled with possible fares and discounts from database
        public SelectList FareList { get; set; }
        public SelectList DiscountList { get; set; }
    }

    // TODO: move into its own file?
    public class RequiredWhenGiftAidingAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Whether they're gift aiding or not
            bool giftAiding = (bool)validationContext.ObjectType.GetProperty("Giftaid").GetValue(validationContext.ObjectInstance, null);

            // If they're not gift aiding then everything is fine
            if (!giftAiding) return ValidationResult.Success;

            // Otherwise, if this field is null/empty, validation fails
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
    }
}