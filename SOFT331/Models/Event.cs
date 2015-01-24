using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, MaxLength(2000)]
        public string Description { get; set; }

        public virtual ICollection<Train> Trains { get; set; }
    }
}