using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //To pass list of Departments from the controller, store them in "ViewBag"
        public ActionResult Index()
        {
            // Connect to the database
            EmployeeContext db = new EmployeeContext();
            // Retrieve departments, and build SelectList
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");

            return View();
        }


    }
}