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
            //Run the application and navigate to the following URL. http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
            //Submit the page without entering any data.We now get an error stating -The model of type 'BusinessLayer.Employee' could not be updated. 
            //Notice that this error is thrown when UpdateModel() function is invoked.
            //Now let's use TryUpdateModel() instead of UpdateModel(). 
            //Run the application and navigate to the following URL http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
            //Submit the page without entering any data.Notice that, we don't get an exception now and the user remains on "Create"
            //view and the validation errors are displayed to the user.So, the difference is UpdateModel() throws an exception if 
            //validation fails, where as TryUpdateModel() will never throw an exception.
            TryUpdateModel<EmployeeFromBusinessLayer>(employee);          

            if (ModelState.IsValid)
            {               
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}