using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ProductModel
    {
        public Int32 ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public String ProductName { get; set;}

        [Required]
        [Display(Name = "Price")]  
        public Decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Int32 CategoryId { get; set; }

       
        public string ImgPath { get; set; }

    
        public string Quntity { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose File")]
        public HttpPostedFileBase ImageUpload { get; set; }


        public Item item{ get; set; }

        //[Required]
        //[Display(Name = "Product Name")]
        //public String ProductName { get; set;}
        //public List<HttpPostedFileBase> Files { get; set; }
    }
}