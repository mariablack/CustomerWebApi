using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomersWebApi.Models;
using log4net;

namespace CustomersWebApi.Controllers
{
    public class CustomerContactsController : ApiController
    {
        private ICustomerContactsAppContext db = new CustomersWebApiContext();

        public CustomerContactsController() { }

        public CustomerContactsController(CustomersWebApiContext context)
        {
            db = context;
        }

        //log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/CustomerContacts
        public IQueryable<CustomerContacts> GetCustomerContacts()
        {
            return db.CustomerContacts
                .Include(b => b.Customer);
        }

        // GET: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContacts))]
        public IHttpActionResult GetCustomerContacts(int id)
        {
            CustomerContacts customerContacts = db.CustomerContacts.Find(id);
            if (customerContacts == null)
            {
                log.Error("GetCustomerContacts method: Customer id did not found");
                return NotFound();
            }

            return Ok(customerContacts);
        }

        // PUT: api/CustomerContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerContacts(int id, CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                log.Error("PutCustomerContacts method: InValid ModelState");
                return BadRequest(ModelState);
            }

            if (id != customerContacts.Id)
            {
                log.Error("PutCustomerContacts method: Wrong Customer id");
                return BadRequest();
            }

            db.MarkAsModifiedContact(customerContacts);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactsExists(id))
                {
                    log.Error("PutCustomerContacts method: Customer id did not found");
                    return NotFound();
                }
                else
                {
                    log.Error("PutCustomerContacts method: Exception thrown in db.SaveChangesAsync()");
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerContacts
        [ResponseType(typeof(CustomerContacts))]
        public IHttpActionResult PostCustomerContacts(CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                log.Error("PostCustomerContacts method: Invalid ModelState");
                return BadRequest(ModelState);
            }

            db.CustomerContacts.Add(customerContacts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerContacts.Id }, customerContacts);
        }

        // DELETE: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContacts))]
        public IHttpActionResult DeleteCustomerContacts(int id)
        {
            CustomerContacts customerContacts = db.CustomerContacts.Find(id);
            if (customerContacts == null)
            {
                log.Error("DeleteCustomer method: Customer did not found");
                return NotFound();
            }

            db.CustomerContacts.Remove(customerContacts);
            db.SaveChanges();

            return Ok(customerContacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerContactsExists(int id)
        {
            return db.CustomerContacts.Count(e => e.Id == id) > 0;
        }
    }
}