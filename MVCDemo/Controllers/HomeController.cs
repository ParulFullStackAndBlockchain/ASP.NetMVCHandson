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
    }
}