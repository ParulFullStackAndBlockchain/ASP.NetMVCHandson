using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //Why the return type is ActionResult and not ViewResult: A contoller action method can do more
        // than just returning a view.It can return another action method or can return a json result.
        public ActionResult Index()
        {
            //Storing list of countries inside dynamic property Countries of ViewBag object.
            ViewBag.Countries =new List<string> {
                "India",
                "US",
                "UK",
                "Canada"
            };
            return View();
        }

        //// O/P of below Action metod - System.Collections.Generic.List`1[System.String]
        //public List<string> Index()
        //{
        //    return new List<string> {
        //        "India",
        //        "US",
        //        "UK",
        //        "Canada"
        //    };
        //}

    }
}