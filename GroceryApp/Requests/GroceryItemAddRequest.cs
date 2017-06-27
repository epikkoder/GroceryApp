using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryApp.Requests
{
    public class GroceryItemAddRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int ItemType { get; set; }
        public double Price { get; set; }
        [MaxLength(50)]
        public string PriceType { get; set; }
        public int Quantity { get; set; }
        public Guid CreatedBy { get; set; }
    }
}