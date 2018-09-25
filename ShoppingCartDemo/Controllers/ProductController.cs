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
    public class ProductController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.ProductEntities.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntities productEntities = db.ProductEntities.Find(id);
            if (productEntities == null)
            {
                return HttpNotFound();
            }
            return View(productEntities);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            List<SupplierEntities> listSupplier = db.SupplierEntities.ToList();
            ViewBag.listSupplier = listSupplier;
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,Name,Description,Supplier,Price")] ProductEntities productEntities)
        {
            if (ModelState.IsValid)
            {
                db.ProductEntities.Add(productEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productEntities);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntities productEntities = db.ProductEntities.Find(id);
            if (productEntities == null)
            {
                return HttpNotFound();
            }
            return View(productEntities);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,Name,Description,Supplier,Price")] ProductEntities productEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productEntities);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntities productEntities = db.ProductEntities.Find(id);
            if (productEntities == null)
            {
                return HttpNotFound();
            }
            return View(productEntities);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEntities productEntities = db.ProductEntities.Find(id);
            db.ProductEntities.Remove(productEntities);
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
