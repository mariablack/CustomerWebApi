using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersWebApi.Models
{
    public class CustomerContacts
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }


        // Navigation property
        public Customer Customer { get; set; }
    }
}