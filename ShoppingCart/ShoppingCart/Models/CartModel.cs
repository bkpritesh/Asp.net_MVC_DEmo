using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class CartModel
    {
        //public int ProductID { get; set; }
        //public Guid SOGUID { get; set; }
        //public string ProductName { get; set; }
        //public Decimal Price { get; set; }
        //public string ImgPath { get; set; }
        //public string Quntity { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImgPath { get; set; }
        public Nullable<decimal> Quntity { get; set; }
    }
}