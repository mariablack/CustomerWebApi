using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}