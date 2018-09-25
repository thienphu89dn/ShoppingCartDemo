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
    public class SupplierController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.SupplierEntities.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierEntities supplierEntities = db.SupplierEntities.Find(id);
            if (supplierEntities == null)
            {
                return HttpNotFound();
            }
            return View(supplierEntities);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SID,Name")] SupplierEntities supplierEntities)
        {
            if (ModelState.IsValid)
            {
                db.SupplierEntities.Add(supplierEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierEntities);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierEntities supplierEntities = db.SupplierEntities.Find(id);
            if (supplierEntities == null)
            {
                return HttpNotFound();
            }
            return View(supplierEntities);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID,Name")] SupplierEntities supplierEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierEntities);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierEntities supplierEntities = db.SupplierEntities.Find(id);
            if (supplierEntities == null)
            {
                return HttpNotFound();
            }
            return View(supplierEntities);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierEntities supplierEntities = db.SupplierEntities.Find(id);
            db.SupplierEntities.Remove(supplierEntities);
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
