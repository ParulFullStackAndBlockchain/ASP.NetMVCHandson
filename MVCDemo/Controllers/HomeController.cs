using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //ASP.Net MVC will automatically pass any query string or form post parameters named "name"
        //to index action methodwhen it is invoked.Eg: http://localhost/MVCDemo/Home/Index/10?name=cat
        public string Index(string id,string name)
        {
            return "The value of Id = " + id + " and Name = " + name;
        }

        ////Input Eg: http://localhost/MVCDemo/Home/Index/10
        //public string Index(string id)
        //{
        //    return "The value of Id = " + id;
        //}

        public string GetDetails()
        {
            return "GetDetails Invoked";
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
    }
}