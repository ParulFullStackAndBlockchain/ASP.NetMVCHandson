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

        //You can control or influence which action method gets invoked using action selectors in mvc. Action selectors
        //are attributes that can be applied to an action method in a controller.

        //ActionName selector: This action selector is used when you want to invoke an action method with a different name,
        //than what is already given to the action method. 

        //AcceptVerbs selector: Use this selector, when you want to control, the invocation of an action method based on the 
        //request type.The default is GET. So, if you don't decorate an action method with any accept verb, then, by default,
        //the method responds to GET request.

        //Note: HttpGet and HttpPost attributes can be used as shown below. This is an alternative to using AcceptVerbs 
        //attribute.

        [AcceptVerbs(HttpVerbs.Get)]
        [ActionName("List")]
        public ActionResult Index()
        {
            //List should be the view name. In case, you want to use "Index" use below lineof code.
            return View("Index", db.Employees.ToList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        //[HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            db.Employees.Where(x => employeeIdsToDelete.Contains(x.ID)).ToList().ForEach(y => db.Employees.Remove(y));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}