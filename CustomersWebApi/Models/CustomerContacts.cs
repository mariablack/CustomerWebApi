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

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }


        // Foreign Key
        public int CustomerId { get; set; }


        // Navigation property
        public Customer Customer { get; set; }
    }
}