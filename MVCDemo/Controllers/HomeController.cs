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
        [HttpGet]
        public ActionResult Index()
        {
            Company company = new Company();
            return View(company);
        }

        [HttpPost]
        public string Index(Company company)
        {
            if (string.IsNullOrEmpty(company.SelectedDepartment))
            {
                return "You did not select any department";
            }
            else
            {
                return "You selected department with ID = " + company.SelectedDepartment;
            }
        }//Note : when we press button we post back to the server and post Form Data Contains this "SelectedDepartment:3".
        //and we have parameter "Company" for our Post Index Action Method. So when "SelectedDepartment" matches with our 
        //"Company.SelectedDepartment" it will auto bind to this property(becasue names match).
        //if Post Index Action Method had parameter "String SelectedDepartment" as shown below
        //it would have worked the same way

        //[HttpPost]
        //public string Index(string SelectedDepartment)
        //{
        //    if (string.IsNullOrEmpty(SelectedDepartment))
        //    {
        //        return "You did not select any department";
        //    }
        //    else
        //    {
        //        return "You selected department with ID = " + SelectedDepartment;
        //    }
        //}


    }
}