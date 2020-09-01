using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    //At this point, "Authorize" attribute is applicable for all action methods in the HomeController. So, only 
    //authenticated users will be able to access SecureMethod() and NonSecureMethod().
    [Authorize]
    public class HomeController : Controller
    {
        //To allow anonymous access to NonSecureMethod(), apply [AllowAnonymous] attribute. AllowAnonymous attribute is 
        //used to skip authorization enforced by Authorize attribute. 
        [AllowAnonymous]
        public ActionResult NonSecureMethod()
        {
            return View();
        }
       
        public ActionResult SecureMethod()
        {
            return View();
        }
    }
}