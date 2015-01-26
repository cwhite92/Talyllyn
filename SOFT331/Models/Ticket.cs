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

        [Required]
        public int TimetableId { get; set; }

        [Required]
        public int FareId { get; set; }

        public int? DiscountId { get; set; }

        [Required, OneWheelchairPerTrain]
        public bool Wheelchair { get; set; }
        public string WheelchairStatusString
        {
            get { return string.Format("{0}", this.Wheelchair ? "Yes" : "No") }
        }

        public virtual Fare Fare { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Timetable Timetable { get; set; }
    }

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