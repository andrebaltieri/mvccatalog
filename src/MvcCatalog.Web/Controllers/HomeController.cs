using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcCatalog.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult ValidateEmail(string email)
        {
            return new JsonResult()
            {
                Data = (email == "andrebaltieri@gmail.com"),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}