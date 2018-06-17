using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class MainController : Controller
    {
        public class P
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Country { get; set; }
        }

        // GET: Main
        public ActionResult Index()
        {
            return View(new P() { FirstName = "Peter", LastName = "Parker", Age = 22, Country = "Lithuania" });
        }
    }
}