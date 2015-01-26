using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SOFT331.Models
{
    public class FareGroup
    {
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(5)]
        public string Name { get; set; }

        public virtual ICollection<Fare> Fares { get; set; }
    }
}