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
        public ActionResult Index()
        {
            Company company = new Company("GoDigitalPro");

            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;

            return View();
        }

        //Notice that we are passing "Company" object to the View, and hence the view is strongly typed.
        //Since the view is strongly typed, we can use TextBoxFor and DropDownListFor HTML helpers.
        public ActionResult Index1()
        {
            Company company = new Company("GoDigitalPro");
            return View(company);
        }
    }
}