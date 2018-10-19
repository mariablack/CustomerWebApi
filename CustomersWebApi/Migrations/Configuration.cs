namespace CustomersWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CustomersWebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomersWebApi.Models.CustomersWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomersWebApi.Models.CustomersWebApiContext context)
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


            context.Customers.AddOrUpdate(x => x.Id,
                new Customer() { Id = 1, Title = "Coca-Cola Hellas", NumberOfEmployees = 300 },
                new Customer() { Id = 2, Title = "Unilever", NumberOfEmployees = 250 },
                new Customer() { Id = 3, Title = "Nestle", NumberOfEmployees = 100 }
                     );

            context.CustomerContacts.AddOrUpdate(x => x.Id,
                new CustomerContacts() {  Id = 1, FirstName = "Giorgos", LastName = "Papadopoulos", CustomerId = 1, Email = "g.papadopoulos@test.com" },
                new CustomerContacts() {  Id = 2, FirstName = "Nikos", LastName = "Pappas", CustomerId = 2, Email = "n.pappas@test.com"  },
                new CustomerContacts() {  Id = 3, FirstName = "Eleni", LastName = "Markou", CustomerId = 3, Email = "e.markou@test.com" },
                new CustomerContacts() {  Id = 4, FirstName = "Kostas", LastName = "Petrou", CustomerId = 1, Email = "k.petrou@test.com" }
                );
        }
    }
}
