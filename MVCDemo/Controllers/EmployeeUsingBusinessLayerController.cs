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
            EmployeeBusinessLayer employeeBusinessLayer =new EmployeeBusinessLayer();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            EmployeeFromBusinessLayer employee = employeeBusinessLayer.EmployeesFromBusinessLayer.First(emp => emp.ID == id);
            return View(employee);
        }

        //Instead of passing "Employee" object as a parameter to "Create_Post()" action method, 
        //we are creating an instance of an "Employee" object with in the function, and updating it using "UpdateModel()" function. 
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            EmployeeFromBusinessLayer employee = new EmployeeFromBusinessLayer();          
            TryUpdateModel<EmployeeFromBusinessLayer>(employee);          

            if (ModelState.IsValid)
            {               
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            EmployeeFromBusinessLayer employee = employeeBusinessLayer.EmployeesFromBusinessLayer.Single(x => x.ID == id);
            //Note: that we are explicitly calling the model binder, by calling UpdateModel() function passing in our interface
            //IEmployee. The model binder will update only the properties that are present in the interface.So, if we were to 
            //generate a post request using fiddler, "Name" property of the "Employee" object will not be updated.
            UpdateModel<IEmployeeFromBusinessLayer>(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }      
    }
}