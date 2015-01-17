using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SOFT331.Models
{
    public class Train
    {
        private const int DEFAULT_CAPACITY = 150;
        private int _capacity = DEFAULT_CAPACITY;

        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(5)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2000)]
        public string Description { get; set; }

        [Required, RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Year must be in format XXXX."), Display(Name = "Production Year")]
        public int Year { get; set; }

        [Required, DefaultValue(DEFAULT_CAPACITY), Display(Name = "Seating Capacity")]
        public int Capacity {
            get { return _capacity; }
            set { _capacity = value; }
        }
    }
}