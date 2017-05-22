using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace henning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = new FilePathResult("~/grand-legacy.html", "text/html");
            return result;
        }



        public ActionResult grand()
        {
            var result = new FilePathResult("~/grand-legacy.html", "text/html");
            return result;
        }
    }
}