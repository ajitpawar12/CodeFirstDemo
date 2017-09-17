using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstDemo.Context;
using CodeFirstDemo.Models;
using System.IO;

namespace CodeFirstDemo.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db=new ProductContext();
        // GET: Product
        public ActionResult Index()
        {
            Product product=new Product();
            
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var productdetails = db.Products.Single(x => x.ProductId == id);
            return View(productdetails);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product products=new Product();

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase image1)
        {
            
            if (image1 != null && image1.ContentLength > 0)
            {
                var name = System.IO.Path.GetFileName(image1.FileName);
                var path = "images/" +name ;
                image1.SaveAs(Server.MapPath("~/images/"+ name));
                product.Picture= path;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Response.Write("Please select image");
            }
            return RedirectToAction("Index","Product");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var productdetails = db.Products.Single(x => x.ProductId == id);
            
            return View(productdetails);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase uploadimage)
        {
            var editdetails = db.Products.Single(x => x.ProductId == product.ProductId);
            var imagepath = product.Picture;

            if (uploadimage != null&&uploadimage.ContentLength>0)
            {
                var name = System.IO.Path.GetFileName(uploadimage.FileName);
                var path = "images/" + name;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                uploadimage.SaveAs(Server.MapPath("~/images/" + name));
                imagepath = path;
            }
            editdetails.Description = product.Description;
            editdetails.Name = product.Name;
            editdetails.Price = product.Price;
            editdetails.Picture = imagepath;
            db.SaveChanges();
            return RedirectToAction("Index","Product");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var productdetails = db.Products.Single(x => x.ProductId == id);
            db.Products.Remove(productdetails);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        //Upload multiple images
        public ActionResult MultipleUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultipleUpload(string data)
        {
            var count = Request.Files.Count;

            for (int i = 0; i < count; i++)
            {
                var file = Request.Files[i];

                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    var extension = Path.GetExtension(filename);
                }
            }
            return View();
        }

        public ActionResult Productimages()
        {

            return View();
        }
    }
}
