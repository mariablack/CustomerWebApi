using CustomersWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersWebApi.Tests
{
    class TestCustomerContactsDbSet :TestDbSet<CustomerContacts>
    {
        public override CustomerContacts Find(params object[] keyValues)
        {
            return this.SingleOrDefault(customerContact => customerContact.Id == (int)keyValues.Single());
        }
    }
}
