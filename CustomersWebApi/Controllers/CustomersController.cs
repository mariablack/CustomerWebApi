using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using CustomersWebApi.Models;
using log4net;

namespace CustomersWebApi.Controllers
{
    public class CustomersController : ApiController
    {
        //log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ICustomerAppContext db = new CustomersWebApiContext();

        public CustomersController() { }

        public CustomersController(ICustomerAppContext context)
        {
            db = context;
        }

        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                log.Error($"GetCustomer method: Customer id {id} did not found");
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"PutCustomer method: InValid ModelState for customer with id {id}");
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                log.Error($"PutCustomer method: Wrong Customer id {id}");
                return BadRequest();
            }

            db.MarkAsModifiedCustomer(customer);


            try
            {
                 db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    log.Error($"PutCustomer method: Customer id {id} did not found");
                    return NotFound();
                }
                else
                {
                    log.Error("PutCustomer method: Exception thrown in db.SaveChanges()");
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"PostCustomer method: Invalid ModelState with id {customer.Id}");
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                log.Error($"DeleteCustomer method: Customer with id {id} did not found");
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

        

    }
}