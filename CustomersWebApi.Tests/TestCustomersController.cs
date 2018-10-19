using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersWebApi.Controllers;
using CustomersWebApi.Models;
using System.Web.Http.Results;

namespace CustomersWebApi.Tests
{
    [TestClass]
    public class TestCustomersController
    {
        [TestMethod]
        public async void GetAllCustomers_ShouldReturnAllCustomersAsync()
        {
            // Set up Prerequisites  
            var controller = new CustomersController();
            
            var result = await controller.GetCustomer(1) as OkNegotiatedContentResult<Customer>;
            // Assert the result  
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }


        private List<Customer> GetTestCustomers()
        {
            var testCustomers = new List<Customer>();
            testCustomers.Add(new Customer { Id = 1, Title = "aaa", NumberOfEmployees = 10 });
            testCustomers.Add(new Customer { Id = 2, Title = "bbb", NumberOfEmployees = 20 });
            testCustomers.Add(new Customer { Id = 3, Title = "ccc", NumberOfEmployees = 30 });
            testCustomers.Add(new Customer { Id = 4, Title = "ddd", NumberOfEmployees = 40 });

            return testCustomers;
        }
    }
}
