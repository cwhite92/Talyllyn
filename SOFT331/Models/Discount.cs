using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Discount
    {
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2000)]
        public string Description { get; set; }

        [Required, Range(1, 100, ErrorMessage = "Discount must be between 1 and 100%."), Display(Name = "Discount Amount")]
        public int DiscountAmount { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return string.Format("{0} (-{1}%)", this.Name, this.DiscountAmount);
        }
    }
}