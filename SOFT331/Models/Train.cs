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
        private int capacity = DEFAULT_CAPACITY;

        public int Id { get; set; }

        public int? EventId { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2000)]
        public string Description { get; set; }

        [Required, Display(Name = "Production Year"), Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        [Required, DefaultValue(DEFAULT_CAPACITY), Display(Name = "Seating Capacity")]
        public int Capacity {
            get { return capacity; }
            set { capacity = value; }
        }

        [Required, Range(1, int.MaxValue)]
        public int AdvancedTickets { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}