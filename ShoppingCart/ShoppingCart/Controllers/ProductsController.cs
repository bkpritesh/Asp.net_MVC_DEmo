using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.EF;
using ShoppingCart.Models;
using System.Drawing.Imaging;
using System.IO;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {

        DemoMVCEntities db = new DemoMVCEntities();
        // GET: Products
        //public ActionResult Index()
        //{
        //    ViewBag.Categories = db.Categories.Where(x => x.Active == true);
        //    var model = new ProductModel();
        //    return View(model);
        //}
        public ActionResult Create()
        {            
            ViewBag.Categories = db.Categories.Where(x => x.Active == true);
            var model = new ProductModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model, HttpPostedFileBase ImageUpload)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                var imageName = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                var extension = System.IO.Path.GetExtension(model.ImageUpload.FileName).ToLower();

                using (var img = System.Drawing.Image.FromStream(model.ImageUpload.InputStream))
                {
                    product.ImgPath = String.Format("/ProductImages/{0}{1}", imageName, extension);
                    var path = Path.Combine(Server.MapPath("/ProductImages"), imageName + extension);
                    ImageUpload.SaveAs(path);
                }
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.message = "Product added successful !!";
                //return RedirectToAction("Create");                
            }
            //ViewBag.message = "Added !!";
            ViewBag.Categories = db.Categories.Where(x => x.Active == true);
            return View(model);

        }
        private void SaveToFolder(string ImagePath, HttpPostedFileBase postedFile)
        {
            var path = Path.Combine(Server.MapPath("ProductImages"));
            postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
        }
    }
}