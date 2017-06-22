using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryApp.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemType { get; set; }
        public double Price { get; set; }
        public string PriceType { get; set; }
        public int Quantity { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}