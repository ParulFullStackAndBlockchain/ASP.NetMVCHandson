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

        //"ActionName" is specified as "Create" for both of these methods. So, if a "GET" request is made to the "URL 
        //- http://localhost/MVCDemo/Employee/Create" then "Create_Get()" controller action method is invoked. 
        //On the other hand if a "POST" request is made to the same URL, then "Create_Post()" controller action method is invoked.
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        //Instead of passing "Employee" object as a parameter to "Create_Post()" action method, 
        //we are creating an instance of an "Employee" object with in the function, and updating it using "UpdateModel()" function. 
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                    new EmployeeBusinessLayer();

                EmployeeFromBusinessLayer employee = new EmployeeFromBusinessLayer();
                // "UpdateModel()" function inspects all the HttpRequest inputs such as posted Form data, QueryString, Cookies
                // and Server variables and populate the employee object.
                UpdateModel<EmployeeFromBusinessLayer>(employee);

                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}