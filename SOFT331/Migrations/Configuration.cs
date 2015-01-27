namespace SOFT331.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SOFT331.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SOFT331.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SOFT331.Models.DatabaseContext context)
        {
            // Create Admin role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // Create Clerk role
            if (!context.Roles.Any(r => r.Name == "Clerk"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Clerk" };

                manager.Create(role);
            }

            // Create admin user account
            if (!context.Users.Any(u => u.UserName == "admin@talyllyn.co.uk"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@talyllyn.co.uk" };

                manager.Create(user, "Admin123!");
                manager.AddToRole(user.Id, "Admin");
            }

            // Create clerk user account
            if (!context.Users.Any(u => u.UserName == "clerk@talyllyn.co.uk"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "clerk@talyllyn.co.uk" };

                manager.Create(user, "Clerk123!");
                manager.AddToRole(user.Id, "Clerk");
            }

            // Create trains
            List<Train> trains = new List<Train>
            {
                new Train { Name = "Talyllyn", Description = "Originally built in 1864 by Fletcher, Jennings & Co. of Whitehaven as an 0-4-0ST, \"Talyllyn\" had a short wheelbase and long rear overhang which led to its rapid conversion to an 0-4-2ST. As the more popular of the line's two original locos \"Talyllyn\" was in very poor condition by 1945 when it was laid aside. It was rebuilt in 1957-58 by Gibbons Bros. Ltd. but proved problematic and has undergone considerable modification since then, resulting in a much improved performance. It is currently running in black livery.", Year = new DateTime(1864, 1, 1), Capacity = 150, AdvancedTickets = 150 },
                new Train { Name = "Dolgoch", Description = "\"Dolgoch\" was built in 1866 by Fletcher, Jennings & Co., but to a very different design to that of \"Talyllyn\". It is an 0-4-0 tank engine with both a back tank (behind the cab) and a well tank (between the frames). The long wheelbase allows the firebox to sit in front of the rear axle, with Fletcher's Patent inside valve gear driven off the front axle, a particularly inaccessible arrangement. In increasingly decrepit condition \"Dolgoch\" continued to operate the service single-handedly until 1952 when \"Edward Thomas\" became available and was then the subject of a prolonged overhaul between 1954 and 1963.", Year = new DateTime(1866, 1, 1), Capacity = 150, AdvancedTickets = 150 },
                new Train { Name = "Sir Haydn", Description = "Built in 1878 by Hughes' Loco & Tramway Eng. Works Ltd of Loughborough this 0-4-2ST (originally 0-4-0ST) worked on the nearby Corris Railway until the closure of that line in 1948. In 1951 it was purchased by the Talyllyn Railway (along with the other surviving Corris loco which became \"Edward Thomas\") and was named after the line's late owner, Sir Henry Haydn Jones. The precarious state of the track led to its being little used for the first few years, and firebox problems caused its withdrawal in 1957. It re-entered service in 1968. \"Sir Haydn\" is current running in Corris Railway red livery.", Year = new DateTime(1878, 1, 1), Capacity = 150, AdvancedTickets = 150 },
                new Train { Name = "Edward Thomas", Description = "This 0-4-2ST was built in 1921 by Kerr, Stuart & Co. Ltd. for use on the Corris Railway, and was purchased by the Talyllyn in 1951 and named after the TR's former manager. After repairs carried out by the Hunslet Engine Co., the engine entered service on the Talyllyn in 1952 and has proved most successful. From 1958 until 1969 a Giesel ejector was fitted instead of a conventional chimney, the first such installation in the British Isles.", Year = new DateTime(1921, 1, 1), Capacity = 150, AdvancedTickets = 150 },
                new Train { Name = "Douglas", Description = "This 0-4-0WT was built in 1918 by Andrew Barclay & Co. Ltd. for the Airservice Construction Corps. From 1921 until 1945 it worked at the RAF railway at Calshot Spit, Southampton. After a period in store at Calshot it was bought in 1949 by Abelson & Co. (Engineers) Ltd. who presented it to the Talyllyn in 1953. After overhaul and alteration from 2ft to 2ft 3in gauge, it entered service in 1954 and was named \"Douglas\" at the donor's request. Although smaller than the other locos it has performed well and was returned to service in 1995, having been fitted with a new boiler, turned out in its old Air Ministry Works & Buildings livery. It is now painted red and running in the guise of Duncan.", Year = new DateTime(1918, 1, 1), Capacity = 150, AdvancedTickets = 150 },
                new Train { Name = "Tom Rolt", Description = "\"Tom Rolt\" was built at the Talyllyn's Pendre Works, incorporating components of a little-used 3ft gauge Andrew Barclay 0-4-0WT built in 1949 for Bord na Mona (the Irish turf board). An 0-4-2T, it is the line's newest, largest and most powerful steam locomotive, having entered service in 1991. It is named after the author L.T.C. Rolt who inspired the Talyllyn's preservation and was its General Manager in 1951-52.", Year = new DateTime(1991, 1, 1), Capacity = 150, AdvancedTickets = 150 }
            };
            trains.ForEach(t => context.Trains.Add(t));
            context.SaveChanges();

            // Create stations
            List<Station> stations = new List<Station>
            {
                new Station { Name = "Tywyn Wharf" },
                new Station { Name = "Pendre" },
                new Station { Name = "Rhydyronen" },
                new Station { Name = "Brynglas" },
                new Station { Name = "Dolgoch Falls" },
                new Station { Name = "Abergynolwyn" },
                new Station { Name = "Nant Gwernol" }
            };
            stations.ForEach(s => context.Stations.Add(s));
            context.SaveChanges();

            // Create fare groups
            List<FareGroup> fareGroups = new List<FareGroup>
            {
                new FareGroup { Name = "Full Line Return & Day Rover" },
                new FareGroup { Name = "Tywyn to Dolgoch Return" },
                new FareGroup { Name = "Other" }
            };
            fareGroups.ForEach(f => context.FareGroups.Add(f));
            context.SaveChanges();

            // Create fares
            List<Fare> fares = new List<Fare>
            {
                new Fare { Name = "Adult", Description = "Adults over the age of 15.", Price = (decimal)15.95, FareGroupId = 1 },
                new Fare { Name = "Over 60s", Description = "OAPs over the age of 60.", Price = (decimal)14.30, FareGroupId = 1 },
                new Fare { Name = "Child", Description = "Children aged between 5 and 15.", Price = (decimal)2.20, FareGroupId = 1 },

                new Fare { Name = "Adult", Description = "Adults over the age of 15.", Price = (decimal)12.10, FareGroupId = 2 },
                new Fare { Name = "Over 60s", Description = "OAPs over the age of 60.", Price = (decimal)11.00, FareGroupId = 2 },
                new Fare { Name = "Child", Description = "Children aged between 5 and 15.", Price = (decimal)2.00, FareGroupId = 2 },

                new Fare { Name = "Dog Rover", Description = "For dogs.", Price = (decimal)3.00, FareGroupId = 3 },
                new Fare { Name = "Under 5s", Description = "Children under 5 years old.", Price = (decimal)0.00, FareGroupId = 3 },
            };
            fares.ForEach(f => context.Fares.Add(f));
            context.SaveChanges();

            // Create discounts
            List<Discount> discounts = new List<Discount>
            {
                new Discount { Name = "Carer", Description = "Carers of disabled persons.", DiscountAmount = 20 },
                new Discount { Name = "Disabled child", Description = "Disabled children travel for free.", DiscountAmount = 100 }
            };
            discounts.ForEach(d => context.Discounts.Add(d));
            context.SaveChanges();
        }
    }
}
