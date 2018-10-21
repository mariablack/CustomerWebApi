using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersWebApi.Models
{
    public interface ICustomerContactsAppContext : IDisposable
    {
        DbSet <CustomerContacts> CustomerContacts { get; }
        int SaveChanges();
        void MarkAsModifiedContact(CustomerContacts customerContacts);
    }
}
