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

namespace CustomersWebApi.Controllers
{
    public class CustomerContactsController : ApiController
    {
        private CustomersWebApiContext db = new CustomersWebApiContext();

        // GET: api/CustomerContacts
        public IQueryable<CustomerContacts> GetCustomerContacts()
        {
            return db.CustomerContacts.Include(b => b.Customer);
        }

        // GET: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContacts))]
        public async Task<IHttpActionResult> GetCustomerContacts(int id)
        {
            CustomerContacts customerContacts = await db.CustomerContacts.FindAsync(id);
            if (customerContacts == null)
            {
                return NotFound();
            }

            return Ok(customerContacts);
        }

        // PUT: api/CustomerContacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerContacts(int id, CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerContacts.Id)
            {
                return BadRequest();
            }

            db.Entry(customerContacts).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerContacts
        [ResponseType(typeof(CustomerContacts))]
        public async Task<IHttpActionResult> PostCustomerContacts(CustomerContacts customerContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerContacts.Add(customerContacts);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerContacts.Id }, customerContacts);
        }

        // DELETE: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContacts))]
        public async Task<IHttpActionResult> DeleteCustomerContacts(int id)
        {
            CustomerContacts customerContacts = await db.CustomerContacts.FindAsync(id);
            if (customerContacts == null)
            {
                return NotFound();
            }

            db.CustomerContacts.Remove(customerContacts);
            await db.SaveChangesAsync();

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