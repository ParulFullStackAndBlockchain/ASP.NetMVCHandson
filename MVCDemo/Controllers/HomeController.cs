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
        //To have the "IT" department selected, when the departments are loaded from tblDepartment table, use the following
        //overloaded constructor of "SelectList" class. 
        //ViewBag.Departments = new SelectList(db.Departments, "Id", "Name", "1");
        //Notice that we are passing a value of "1" for "selectedValue" parameter. 
        //Basically we are hard-coding the "selectedValue" in code 

        //Code to drive the selection of an item in the dropdownlist using a column in tblDepartment table.
        public ActionResult Index()
        {
            EmployeeContext db = new EmployeeContext();
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Department department in db.Departments)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = department.Name,
                    Value = department.Id.ToString(),
                    Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
                };
                selectListItems.Add(selectListItem);
            }

            ViewBag.Departments = selectListItems;
            return View();
        }
    }
}