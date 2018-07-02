using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    //ViewBag.Title = "Home Page";

        //    return View("~/wwwroot/index.html");
        //}

        public ActionResult Spa()
        {
            return File("~/index.html", "text/html");
        }
    }
}
