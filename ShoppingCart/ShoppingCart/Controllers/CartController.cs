using ShoppingCart.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        DemoMVCEntities db = new DemoMVCEntities();
        
        // GET: Cart
        public ActionResult Index()
        {
            //var CartItem = db.sp_GetShoppingCartItem(new Guid(Session["SOGUID"].ToString()));
            //return View(CartItem);


            List<CartModel> CartList = new List<CartModel>();
            if (Session["SOGUID"] != null)
            {
                //var Cart=from c in db.Carts
                //         where c.SoHeaderGUID == new Guid(Session["SOGUID"].ToString())
                //         select new CartModel() {  }

                //var Cart = db.sp_GetShoppingCartItem(new Guid(Session["SOGUID"].ToString()));
                //foreach (var cart in Cart)
                //{
                //    CartItem.ProductID = cart.ProductID;
                //    CartItem.ProductName = cart.ProductName;
                //    CartItem.Price = cart.Price;
                //    CartItem.Quntity = cart.Quntity;
                //    CartItem.ImgPath = cart.ImgPath;
                //}

                //var Cart = db.Carts.AsEnumerable().Where(x => x.SoHeaderGUID.Equals(Guid.Parse(Session["SOGUID"] as string))).Select(x => x.Product).ToList();
                //var Cart = db.sp_GetShoppingCartItem(new Guid(Session["SOGUID"].ToString()));
                var SOGUID = Guid.Parse(Session["SOGUID"] as string);
                var Cart = (from c in db.Carts
                            join p in db.Products
                            on c.ProductID equals p.ProductID
                            where c.SoHeaderGUID == SOGUID
                            select new
                            {
                                Carts = c,
                                Products = p
                            }).ToList();

                foreach (var item in Cart)
                {
                    CartModel CartItem = new CartModel();
                    CartItem.ProductID = item.Products.ProductID;
                    CartItem.ProductName = item.Products.ProductName;
                    CartItem.Price = item.Products.Price;
                    CartItem.Quntity = item.Carts.Quntity;
                    CartItem.ImgPath = item.Products.ImgPath;
                    CartList.Add(CartItem);
                }


                //ViewBag.CartItem = Cart;
                // return View(CartItem);
            }

            //var product = db.Products.Select(p => p);
            //var pro = from p in db.Carts
            //          select new ProductModel() { ProductName = p.ProductName, ProductID = p.ProductID, Price = (Decimal)p.Price, ImgPath = p.ImgPath };
            //ViewBag.listproduct = pro;
            //var model = new ProductModel();
            //return View(model);
            
            
            //return View();
            return View(CartList);           
        }
    }
}