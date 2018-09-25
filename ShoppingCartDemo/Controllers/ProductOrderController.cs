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
    public class ProductOrderController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: ProductOrder
        public ActionResult Index()
        {
            return View(db.ProductOrderEntities.ToList());
        }

        // GET: ProductOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderEntities productOrderEntities = db.ProductOrderEntities.Find(id);
            if (productOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(productOrderEntities);
        }

        // GET: ProductOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OID,PID,Amount")] ProductOrderEntities productOrderEntities)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrderEntities.Add(productOrderEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productOrderEntities);
        }

        // GET: ProductOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderEntities productOrderEntities = db.ProductOrderEntities.Find(id);
            if (productOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(productOrderEntities);
        }

        // POST: ProductOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OID,PID,Amount")] ProductOrderEntities productOrderEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOrderEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productOrderEntities);
        }

        // GET: ProductOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrderEntities productOrderEntities = db.ProductOrderEntities.Find(id);
            if (productOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(productOrderEntities);
        }

        // POST: ProductOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOrderEntities productOrderEntities = db.ProductOrderEntities.Find(id);
            db.ProductOrderEntities.Remove(productOrderEntities);
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
