using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{   
    public class HomeController : Controller
    {
        // Public action method that can be invoked using a URL request
        public ActionResult Index()
        {
            return View();
        }

        // This method is accessible only by a child request. A runtime 
        // exception will be thrown if a URL request is made to this method
        [ChildActionOnly]
        public ActionResult Countries(List<String> countryData)
        {
            return View(countryData);
        }
    }
}