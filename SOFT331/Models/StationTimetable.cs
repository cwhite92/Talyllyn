using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class StationTimetable
    {
        public int Id { get; set; }

        public int? StationId { get; set; }

        public int TimetableId { get; set; }

        public TimeSpan? Arrival { get; set; }
        public TimeSpan? Departure { get; set; }

        public virtual Station Station { get; set; }
        public virtual Timetable Timetable { get; set; }
    }
}