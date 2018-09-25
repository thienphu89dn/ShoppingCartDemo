using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;

namespace ShoppingCartDemo.Controllers
{
    public class CustomerController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.CustomerEntities.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntities customerEntities = db.CustomerEntities.Find(id);
            if (customerEntities == null)
            {
                return HttpNotFound();
            }
            return View(customerEntities);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CID,Name,Password,Email")] CustomerEntities customerEntities)
        {
            if (ModelState.IsValid)
            {
                db.CustomerEntities.Add(customerEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerEntities);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntities customerEntities = db.CustomerEntities.Find(id);
            if (customerEntities == null)
            {
                return HttpNotFound();
            }
            return View(customerEntities);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID,Name,Password,Email")] CustomerEntities customerEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerEntities);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntities customerEntities = db.CustomerEntities.Find(id);
            if (customerEntities == null)
            {
                return HttpNotFound();
            }
            return View(customerEntities);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerEntities customerEntities = db.CustomerEntities.Find(id);
            db.CustomerEntities.Remove(customerEntities);
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
