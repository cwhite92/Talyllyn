using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Set up many-to-many relationship between Stations and Timetables
            // Entity framework doesn't handle this well, for some reason.
            modelBuilder.Entity<Station>()
                .HasMany(c => c.StationTimetables)
                .WithRequired()
                .HasForeignKey(c => c.StationId);

            modelBuilder.Entity<Timetable>()
                .HasMany(c => c.StationTimetables)
                .WithRequired()
                .HasForeignKey(c => c.TimetableId);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<SOFT331.Models.Train> Trains { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.FareGroup> FareGroups { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Fare> Fares { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Discount> Discounts { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Timetable> Timetables { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.StationTimetable> StationTimetables { get; set; }

        public System.Data.Entity.DbSet<SOFT331.Models.Ticket> Tickets { get; set; }
    }
}