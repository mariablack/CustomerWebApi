using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CustomersWebApi.Models;

namespace CustomersWebApi.Tests
{
    public class TestCustomersWebAppContext : ICustomerAppContext , ICustomerContactsAppContext
    {
        public TestCustomersWebAppContext()
        {
            this.Customers = new TestCustomerDbSet();
            this.CustomerContacts = new TestCustomerContactsDbSet();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContacts> CustomerContacts { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModifiedCustomer(Customer customers) { }

        public void MarkAsModifiedContact(CustomerContacts customerContacts) { }

        public void Dispose() { }
    }
}
