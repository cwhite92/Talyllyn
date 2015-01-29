using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int TimetableId { get; set; }

        [Required]
        public int FareId { get; set; }

        public int? DiscountId { get; set; }

        [Required, OneWheelchairPerTrain]
        public bool Wheelchair { get; set; }

        [MaxLength(50), MinLength(3)]
        public string GiftaidName { get; set; }

        [MaxLength(50), MinLength(3)]
        public string GiftaidAddressFirstLine { get; set; }

        [MaxLength(7), MinLength(5), RegularExpression(@"^(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})$")]
        public string GiftaidPostcode { get; set; }

        // Returns a string representation of whether or not a wheelchair is required
        public string WheelchairStatusString { get { return string.Format("{0}", this.Wheelchair ? "Yes" : "No"); } }

        // Returns the total price of this ticket
        public decimal TotalPrice { get { return this.getTotalPrice(); } }

        // Returns a string representation of the total price, formatted as a currency
        [Display(Name = "Total Price")]
        public string TotalPriceString { get { return string.Format("£{0}", this.getTotalPrice()); } }

        // Relationships
        public virtual Timetable Timetable { get; set; }
        public virtual Fare Fare { get; set; }
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// Return the total price of this ticket based on the fare and any discounts that apply.
        /// </summary>
        private decimal getTotalPrice()
        {
            decimal price = this.Fare.Price;

            if (this.Discount != null)
            {
                // If there is a discount applied to this ticket work out the new price
                decimal discountModifier = Decimal.Divide(this.Discount.DiscountAmount, 100);
                price = price - Decimal.Multiply(price, discountModifier);
            }

            return Math.Round(price, 2);
        }
    }

    // TODO: move into its own file?
    public class OneWheelchairPerTrainAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If this ticket doesn't require wheelchair space we can skip this validation
            if (!(bool)value) return ValidationResult.Success;

            int timetableId = (int)validationContext.ObjectType.GetProperty("TimetableId").GetValue(validationContext.ObjectInstance, null);

            using (DatabaseContext db = new DatabaseContext())
            {
                foreach (Ticket ticket in db.Tickets.Where(t => t.TimetableId == timetableId))
                {
                    // If there's another ticket that has wheelchair access then the validation fails
                    if (ticket.Wheelchair) return new ValidationResult("Sorry, there is only enough space for one wheelchair per train.");
                }
            }

            return ValidationResult.Success;
        }
    }
}