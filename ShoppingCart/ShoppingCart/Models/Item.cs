using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.EF;

namespace ShoppingCart.Models
{
    public class Item
    {
        public Int32 ProductID { get; set; }
        public String ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Quntity { get; set; }
             
        
    }
}