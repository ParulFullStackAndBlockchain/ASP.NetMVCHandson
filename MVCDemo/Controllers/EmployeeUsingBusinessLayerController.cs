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
    }
}