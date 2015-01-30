using SOFT331.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOFT331.ViewModels
{
    public class TimetableCreateViewModel
    {
        // Default values for number of seats and number of advanced tickets
        private const int DEFAULT_SEATS = 150;
        private const int DEFAULT_ADVANCED_TICKETS = 150;

        private int seats = DEFAULT_SEATS;
        private int advancedTickets = DEFAULT_ADVANCED_TICKETS;

        // A nice round default number
        public int maximumStops = 10;

        [Required, Display(Name = "Date"), Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required, Display(Name = "Train")]
        public int TrainId { get; set; }

        [Required, Range(1, int.MaxValue), DefaultValue(DEFAULT_SEATS), Display(Name = "# of Seats")]
        public int Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }

        [Required, NotGreaterThanSeats, Display(Name = "# of Advanced Tickets")]
        public int AdvancedTickets
        {
            get { return this.advancedTickets; }
            set { this.advancedTickets = value; }
        }

        // This will be populated with arrival/departure times
        public IList<StationTimetable> StationTimetables { get; set; }

        // A list of trains to expose to the dropdown
        public SelectList TrainList { get; set; }

        // A list of stations to pick from when setting up arrival/departure times
        private SelectList stationList;
        public SelectList StationList
        {
            get { return stationList; }
            set
            {
                // Maximum number of stations for each timetable.
                // Set to double the number of stations in the database - 1.
                // This is enough for a train to go from the first station
                // to the last and back again.
                maximumStops = (value.Count() * 2) - 1;

                stationList = value;
            }
        }
    }

    public class TimetableIndexViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Train Train { get; set; }

        [Display(Name = "Number of Seats")]
        public int Seats { get; set; }

        [Display(Name = "Number of Advanced Tickets")]
        public int AdvancedTickets { get; set; }

        [Display(Name = "Number of Stops")]
        public IEnumerable<StationTimetable> StationTimetables { get; set; }
    }

    public class NotGreaterThanSeatsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // The number of seats on this train
            int seats = (int)validationContext.ObjectType.GetProperty("Seats").GetValue(validationContext.ObjectInstance, null);

            if ((int)value > seats) return new ValidationResult("Advanced tickets cannot be greater than number of seats.");

            return ValidationResult.Success;
        }
    }
}