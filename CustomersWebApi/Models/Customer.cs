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

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200)]
        public string Title { get; set; }

        [Range(0, 10000, ErrorMessage = "NumberOfEmployees must not be greater than 10000")]
        public int NumberOfEmployees { get; set; }
    }
}