using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserInfo;
using UserInfo.Models;

namespace UserInfo.Controllers
{
    public class Table_1Controller : Controller //Controller Class
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //Initalize Database

        // GET Users from the Database and display them on the main page
        public ActionResult Index()
        {
            return View(db.Table_1.ToList());
        }

        // Get the user details from the Database and display on the "Details" page
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Return Bad Request Status Code if no ID is present
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound(); //Return Http error code if user info does not exist
            }
            return View(table_1);
        }

        
        public ActionResult Create()
        {
            return View(); 
        }

        // Create/Insert a User and their Email Address into the Database

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Email")] Table_1 table_1)
        {
            if (ModelState.IsValid)//If ID is valid then save info to database
            {
                db.Table_1.Add(table_1);//Add Info to Database
                db.SaveChanges();
                return RedirectToAction("Index");//Return to the main page
            }

            return View(table_1);
        }

        // If there's no ID then return a Bad Request
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound();//Return Http error code if user info does not exist
            }
            return View(table_1);
        }

        // Edit User name and Email Address
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Email")] Table_1 table_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");//Return to the main page
            }
            return View(table_1);
        }

        // If there's no ID then return a Bad Request
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_1 table_1 = db.Table_1.Find(id);
            if (table_1 == null)
            {
                return HttpNotFound();//Return Http error code if user info does not exist
            }
            return View(table_1);
        }

        // Delete User Name and Email Address from the Database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_1 table_1 = db.Table_1.Find(id);
            db.Table_1.Remove(table_1);
            db.SaveChanges();
            return RedirectToAction("Index");//Return to the main page
        }

        //Close the Database connection
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); //Close connection 
            }
            base.Dispose(disposing);
        }
    }
}
