using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public string Login()
        {
            return "This method should be accessed only using HTTPS protocol";
        }
    }
}