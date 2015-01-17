using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class Station
    {
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(5)]
        public string Name { get; set; }
    }
}