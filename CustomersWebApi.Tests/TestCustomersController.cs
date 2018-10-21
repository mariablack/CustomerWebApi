using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersWebApi.Controllers;
using CustomersWebApi.Models;
using System.Web.Http.Results;
using System.Net;

namespace CustomersWebApi.Tests
{
    [TestClass]
    public class TestCustomersController
    {
       
            [TestMethod]
            public void PostCustomer_ShouldReturnSameCustomer()
            {
                var controller = new CustomersController(new CustomersWebApiContext());

                var item = GetTestCustomers();

                var result = controller.PostCustomer(item) as CreatedAtRouteNegotiatedContentResult<Customer>;

                Assert.IsNotNull(result);
                Assert.AreEqual(result.RouteName, "DefaultApi");
                Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
                Assert.AreEqual(result.Content.Title, item.Title);
            }

            [TestMethod]
            public void PutCustomer_ShouldReturnStatusCode()
            {
                var controller = new CustomersController(new CustomersWebApiContext());

                var item = GetTestCustomers();

                var result = controller.PutCustomer(item.Id, item) as StatusCodeResult;
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
                Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            }

            [TestMethod]
            public void PutCustomer_ShouldFail_WhenDifferentID()
            {
                var controller = new CustomersController(new CustomersWebApiContext());

                var badresult = controller.PutCustomer(999, GetTestCustomers());
                Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
            }

            [TestMethod]
            public void GetCustomer_ShouldReturnItemWithSameID()
            {
                var context = new CustomersWebApiContext();
                context.Customers.Add(GetTestCustomers());

                var controller = new CustomersController(context);
                var result = controller.GetCustomer(3) as OkNegotiatedContentResult<Customer>;

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Content.Id);
            }

            //[TestMethod]
            //public void GetCustomers_ShouldReturnAllCustomers()
            //{
            //    var context = new CustomersWebApiContext();
            //    context.Customers.Add(new Customer () { Id = 10, Title = "Example1", NumberOfEmployees = 6 });
            //    context.Customers.Add(new Customer () { Id = 11, Title = "Example2", NumberOfEmployees = 7 });
            //    context.Customers.Add(new Customer () { Id = 12, Title = "Example3", NumberOfEmployees = 8 });

            //    var t = context.Customers.Count();

            //    var controller = new CustomersController(context);
            //    var result = controller.GetCustomers() as TestCustomerDbSet;

            //    Assert.IsNotNull(result);
            //    Assert.AreEqual(3, result.Local.Count);
            //}

            [TestMethod]
            public void DeleteCustomer_ShouldReturnOK()
            {
                var context = new CustomersWebApiContext();
                var cust = GetTestCustomers();
                context.Customers.Add(cust);

                var controller = new CustomersController(context);
                var result = controller.DeleteCustomer(3) as OkNegotiatedContentResult<Customer>;

                Assert.IsNotNull(result);
                Assert.AreEqual(cust.Id, result.Content.Id);
            }

            Customer GetTestCustomers()
            {
                return new Customer() { Id = 3, Title = "Demo Title", NumberOfEmployees = 5 };
            }
        }
}
