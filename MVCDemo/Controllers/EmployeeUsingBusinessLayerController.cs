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

        //Notice that, the create action method has got parameter names that match with the names of the form controls. 
        //To see the names of the form controls, right click on the browser and view page source. 
        //Model binder in mvc maps the values of these control, to the respective parameters.
        [HttpPost]
        public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        {
            EmployeeFromBusinessLayer employee = new EmployeeFromBusinessLayer();
            employee.Name = name;
            employee.Gender = gender;
            employee.City = city;
            employee.DateOfBirth = dateOfBirth;

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }

    }
}