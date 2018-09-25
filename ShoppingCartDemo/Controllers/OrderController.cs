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
    public class OrderController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: Order
        public ActionResult Index()
        {
            return View(db.OrderEntities.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntities orderEntities = db.OrderEntities.Find(id);
            if (orderEntities == null)
            {
                return HttpNotFound();
            }
            return View(orderEntities);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OID,CID,OrderDate,OrderDelivery")] OrderEntities orderEntities)
        {
            if (ModelState.IsValid)
            {
                db.OrderEntities.Add(orderEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderEntities);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntities orderEntities = db.OrderEntities.Find(id);
            if (orderEntities == null)
            {
                return HttpNotFound();
            }
            return View(orderEntities);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OID,CID,OrderDate,OrderDelivery")] OrderEntities orderEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderEntities);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntities orderEntities = db.OrderEntities.Find(id);
            if (orderEntities == null)
            {
                return HttpNotFound();
            }
            return View(orderEntities);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderEntities orderEntities = db.OrderEntities.Find(id);
            db.OrderEntities.Remove(orderEntities);
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
