 using System;
using System.Collections.Generic;
 using System.Data.Entity;
 using System.Linq;
using System.Web;
using System.Web.Mvc;
 using CodeFirstDemo.Context;
 using CodeFirstDemo.Models;

namespace CodeFirstDemo.Controllers
{
    public class BlogsController : Controller
    {
        ProductContext db = new ProductContext();
        // GET: Blogs
        public ActionResult Index()
        {
            
            return View(db.Blogs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Blog model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.Blogs.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}