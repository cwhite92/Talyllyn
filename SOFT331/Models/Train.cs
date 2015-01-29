using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOFT331.Models
{
    public class Train
    {
        private const int DEFAULT_CAPACITY = 150;
        private const int DEFAULT_ADVANCED_TICKETS = 150;

        private int capacity = DEFAULT_CAPACITY;
        private int advancedTickets = DEFAULT_ADVANCED_TICKETS;

        public int Id { get; set; }

        public int? EventId { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2000)]
        public string Description { get; set; }

        [Required, Display(Name = "Production Year"), Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        [Required, Range(1, int.MaxValue), DefaultValue(DEFAULT_CAPACITY), Display(Name = "Seating Capacity")]
        public int Capacity {
            get { return capacity; }
            set { this.capacity = value; }
        }

        [Required, NotGreaterThanCapacity, Display(Name = "Advanced Tickets")]
        public int AdvancedTickets
        {
            get { return advancedTickets; }
            set { this.advancedTickets = value; }
        }

        public virtual Event Event { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }

    // TODO: move into its own file?
    public class NotGreaterThanCapacityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // The number of seats on this train
            int capacity = (int)validationContext.ObjectType.GetProperty("Capacity").GetValue(validationContext.ObjectInstance, null);

            if ((int)value > capacity) return new ValidationResult("Advanced tickets cannot be greater than capacity.");

            return ValidationResult.Success;
        }
    }
}