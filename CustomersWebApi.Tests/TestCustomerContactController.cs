using CustomersWebApi.Controllers;
using CustomersWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CustomersWebApi.Tests
{
    [TestClass]
    public class CustomerContactController
    {
        [TestMethod]
        public void PostCustomerContact_ShouldReturnSameContact()
        {
            var controller = new CustomerContactsController(new CustomersWebApiContext());

            var item = GetTestContacts();

            var result = controller.PostCustomerContacts(item) as CreatedAtRouteNegotiatedContentResult<CustomerContacts>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.FirstName, item.FirstName);
        }

        [TestMethod]
        public void PutCustomerContact_ShouldReturnStatusCode()
        {
            var controller = new CustomerContactsController(new CustomersWebApiContext());

            var item = GetTestContacts();

            var result = controller.PutCustomerContacts(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutCustomerContact_ShouldFail_WhenDifferentID()
        {
            var controller = new CustomerContactsController(new CustomersWebApiContext());

            var badresult = controller.PutCustomerContacts(999, GetTestContacts());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetCustomerContact_ShouldReturnItemWithSameID()
        {
            var context = new CustomersWebApiContext();
            context.CustomerContacts.Add(GetTestContacts());

            var controller = new CustomerContactsController(context);
            var result = controller.GetCustomerContacts(3) as OkNegotiatedContentResult<CustomerContacts>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        
        [TestMethod]
        public void DeleteCustomerContact_ShouldReturnOK()
        {
            var context = new CustomersWebApiContext();
            var con = GetTestContacts();
            context.CustomerContacts.Add(con);

            var controller = new CustomerContactsController(context);
            var result = controller.DeleteCustomerContacts(3) as OkNegotiatedContentResult<CustomerContacts>;

            Assert.IsNotNull(result);
            Assert.AreEqual(con.Id, result.Content.Id);
        }

        CustomerContacts GetTestContacts()
        {
            return new CustomerContacts() { Id = 3, FirstName = "FirstNameEx", LastName = "LastNameEx", CustomerId = 1, Email = "a@test.com" };
        }
    }
}

