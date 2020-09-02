using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{   
    public class HomeController : Controller
    {
        //In case you want to handle error in a specific action method and not for all controllers and their action 
        //methods in the entire application.
        //Note: This also requires code inside the FilterConfig.RegisterGlobalFilters) method to be commented.
        //[HandleError]
        public ActionResult Index()
        {
            throw new Exception("Something went wrong");
        }
    }
}