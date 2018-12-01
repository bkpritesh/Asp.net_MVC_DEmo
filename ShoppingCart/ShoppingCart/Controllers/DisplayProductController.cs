using ShoppingCart.EF;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class DisplayProductController : Controller
    {
        DemoMVCEntities db = new DemoMVCEntities();
        // GET: DisplayProduct
        public ActionResult Index()
            {
            //var query = from pro in db.Projects
            //            select new ProjectInfo() { Name = pro.ProjectName, Id = pro.ProjectId };

            //var product = db.Products.Select(p => p);        
            if (Session["SOGUID"] == null)
            {
                Guid SOGUID = Guid.NewGuid();
                Session["SOGUID"] = SOGUID.ToString();
            }
            var pro = from p in db.Products
                      select new ProductModel() {ProductName=p.ProductName,ProductID=p.ProductID,Price=(Decimal)p.Price,ImgPath=p.ImgPath };
            ViewBag.listproduct = pro;
            //var model = new ProductModel();
            //return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult AddToBasket(int? ProductId,int? Quntity)
        {
            string SOGUID = string.Empty;
            if (Session["SOGUID"] != null)
            {
                SOGUID = Session["SOGUID"].ToString();
            }
            Cart cart = new Cart();
            cart.ProductID = ProductId;
            cart.SoHeaderGUID = new Guid(SOGUID);
            cart.Quntity = Quntity;
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}