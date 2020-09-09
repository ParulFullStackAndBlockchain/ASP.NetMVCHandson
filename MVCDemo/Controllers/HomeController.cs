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
    public class HomeController : Controller
    {
        private SampleDbContext db = new SampleDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //Method which gets called to perform the remote validation. An AJAX request is issued to this method. If this method 
        //returns true, validation succeeds, else validation fails and the form is prevented from being submitted. 
        //Note: The parameter name (UserName) must match the field name on the view. If they don't match, model binder will 
        //not be able bind the value with the parameter and validation may not work as expected.
        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!db.Users.Any(x => x.UserName == UserName),
                                                 JsonRequestBehavior.AllowGet);
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //Adding model validation error dynamically in the controller action method, to make server side validation work,
        //when JavaScript is disabled.
        //Now when you will disable JavaScript in the browser, and test your application. You will not get client side 
        //validation, but when you submit the form, server side validation still prevents the user from submitting the form, 
        //if there are validation errors.
        //However, delegating the responsibility of performing validation, to a controller action method violates separation
        //of concerns within MVC.Ideally all validation logic should be in the Model.
        //Using validation attributes in mvc models, should be the preferred method for validation.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,UserName,Password")] User user)
        {
            // Check if the UserName already exists, and if it does, add Model validation error
            if (db.Users.Any(x => x.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "UserName already in use");
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
