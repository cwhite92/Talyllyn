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
    public class Fare
    {
        private int fareGroupId;

        public int Id { get; set; }

        public int FareGroupId { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual FareGroup FareGroup { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}