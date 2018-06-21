namespace API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(API.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(x => x.Id,
              new Core.Entities.Category { Id = 1, Name = "Category 1", Description = "Des 1" },
              new Core.Entities.Category { Id = 2, Name = "Category 2", Description = "Des 2" },
              new Core.Entities.Category { Id = 3, Name = "Category 3", Description = "Des 3" }
            );

            //context.Vendors.AddOrUpdate(x => x.Id,
            //  new Core.Entities.Vendor { Id = 1, Name = "Vendor 1" }
            //);
            context.Products.AddOrUpdate(x => x.Id,
              new Core.Entities.Product { Id = 1, Name = "Product 1", Description = "Des 1", CategoryId = 1, VendorId = 1 },
              new Core.Entities.Product { Id = 2, Name = "Product 2", Description = "Des 2", CategoryId = 1, VendorId = 1 },
              new Core.Entities.Product { Id = 3, Name = "Product 3", Description = "Des 3", CategoryId = 1, VendorId = 1 }
            );



        }
    }
}
