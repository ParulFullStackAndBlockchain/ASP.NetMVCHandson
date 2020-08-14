using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //Suppose the business requirement is such that, we want to display total number of employees by department. 
        //At the moment, either the Employee or Department class does not have Total property. This is one example, where a 
        //Data Transfer Object can be used as a model.
        public ActionResult EmployeesByDepartment()
        {
            var departmentTotals = db.Employees.Include("Department")
                                        .GroupBy(x => x.Department.Name)
                                        .Select(y => new DepartmentTotals
                                        {
                                            Name = y.Key,
                                            Total = y.Count()
                                        }).ToList().OrderBy(y => y.Total);
            return View(departmentTotals);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {            
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        // Prevent updating "Name" property using tools like fiddler without using Bind attribute
        public ActionResult Edit(Employee employee)
        {
            Employee employeeFromDB = db.Employees.Single(x => x.EmployeeId == employee.EmployeeId);
            employeeFromDB.Gender = employee.Gender;
            employeeFromDB.City = employee.City;
            employeeFromDB.DepartmentId = employee.DepartmentId;

            if (ModelState.IsValid)
            {
                db.Entry(employeeFromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
