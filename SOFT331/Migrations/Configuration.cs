namespace SOFT331.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SOFT331.Models;
    using System;
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
        }
    }
}
