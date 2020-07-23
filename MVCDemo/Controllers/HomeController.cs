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
            //Storing list of countries inside ViewData object using the key "Countries"
            //Note : Internally ViewBag properties are stored as name/value pairs in the ViewData dictionary.
            ViewData["Countries"] =new List<string> {
                "India",
                "US",
                "UK",
                "Canada"
            };
            return View();
        }
      

    }
}