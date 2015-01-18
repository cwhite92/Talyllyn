using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOFT331.Models
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public System.Data.Entity.DbSet<SOFT331.Models.Train> Trains { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.FareGroup> FareGroups { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Fare> Fares { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Discount> Discounts { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Timetable> Timetables { get; set; }
    }
}