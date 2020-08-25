using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using System.Data.Entity;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            sampleDBContext db = new sampleDBContext();
            return View(db.Employees.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            sampleDBContext db = new sampleDBContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);          
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            sampleDBContext db = new sampleDBContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                sampleDBContext db = new sampleDBContext();
                Employee employeeFromDB = db.Employees.Single(x => x.Id == employee.Id);

                // Populate all the properties except EmailAddrees
                employeeFromDB.FullName = employee.FullName;
                employeeFromDB.Gender = employee.Gender;
                employeeFromDB.Age = employee.Age;
                employeeFromDB.HireDate = employee.HireDate;
                employeeFromDB.Salary = employee.Salary;
                employeeFromDB.PersonalWebSite = employee.PersonalWebSite;

                db.Entry(employeeFromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View(employee);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
