using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940320055.Models
{
    public class Product
    {
        
        [Key]
        public int ProductId { get; set; }

       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Product  name")]
        public string ProductName { get; set; }

        [DataType(DataType.Text)]
        
        public Decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Category name")]
        public string CategoryName{get;set;}

    }
}