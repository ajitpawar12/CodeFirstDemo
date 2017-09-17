using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstDemo.Models;

namespace CodeFirstDemo.Controllers
{
    public class TexteditorsController : Controller
    {
        // GET: Texteditors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TinyEditor()
        {
            var model=new Editor();

            return View(model);
        }
    }
}