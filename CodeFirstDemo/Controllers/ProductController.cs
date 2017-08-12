using System;
using System.Collections.Generic;
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
            return View();
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
               // var e = System.IO.Path.GetExtension(image1.FileName);
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

            return View("Create");

            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
