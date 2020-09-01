using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private SampleDbContext db = new SampleDbContext();
        
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            db.Employees.Where(x => employeeIdsToDelete.Contains(x.ID)).ToList().ForEach(y => db.Employees.Remove(y));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Suppose Method() is for doing some internal work, and we don't want it to be invoked using a URL request.
        //To achieve this, decorate Method2() with NonAction attribute.
        //Now, if you naviage to URL /Home/Method, you will get an error - The resource cannot be found.
        //Another way to restrict access to methods in a controller, is by making them private.
        [NonAction]
        public string Method()
        {
            return "<h1>Method 2 Invoked</h1>";
        }
        //Note: In general, it's a bad design to have a public method in a controller that is not an action method. If you 
        //have any such method for performing business calculations, it should be somewhere in the model and not in the 
        //controller.
        //However, if for some reason, if you want to have public methods in a controller and you don't want to treat them
        //as actions, then use NonAction attribute.
    }
}