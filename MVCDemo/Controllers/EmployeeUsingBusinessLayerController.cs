using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo.Controllers
{
    public class EmployeeUsingBusinessLayerController : Controller
    {
        // GET: EmployeeUsingBusinessLayer
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =
            new EmployeeBusinessLayer();

            List<EmployeeFromBusinessLayer> employees = employeeBusinessLayer.EmployeesFromBusinessLayer.ToList();
            return View(employees);
        }

        [HttpGet] //This makes this action method to respond only to the "GET" request
        public ActionResult Create()
        {
            return View();
        }

        // Do we really have to write all the dirty code of retrieving data from FormCollection and assign it to the 
        // properties of "employee" object. The answer is no. This is the job of the modelbinder in MVC. 
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            EmployeeFromBusinessLayer employee = new EmployeeFromBusinessLayer();
            // Retrieve form data using form collection
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth =
                Convert.ToDateTime(formCollection["DateOfBirth"]);

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }

    }
}