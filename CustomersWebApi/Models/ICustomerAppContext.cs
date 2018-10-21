using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CustomersWebApi.Models
{
    public interface ICustomerAppContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
        int SaveChanges();
        void MarkAsModifiedCustomer(Customer customer);
    }
}
