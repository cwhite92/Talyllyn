using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    /// <summary>
    /// This model should not be used directly. Instead, it should be used through the Timetables*ViewModel classes
    /// exposed on /ViewModels/TimetableViewModels.cs
    /// </summary>
    public class Timetable
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        [Column(TypeName = "Date"), DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Seats { get; set; }
        public int AdvancedTickets { get; set; }

        // Relationships
        public virtual ICollection<StationTimetable> StationTimetables { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Train Train { get; set; }
    }
}