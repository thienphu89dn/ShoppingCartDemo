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
    public class TempOrderController : Controller
    {
        private MasterModel db = new MasterModel();

        // GET: TempOrder
        public ActionResult Index()
        {
            return View(db.TempOrderEntities.ToList());
        }

        // GET: TempOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempOrderEntities tempOrderEntities = db.TempOrderEntities.Find(id);
            if (tempOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(tempOrderEntities);
        }

        [HttpPost]
        public JsonResult Create(int PID)
        {
            return Json("OK");
        }

        // GET: TempOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempOrderEntities tempOrderEntities = db.TempOrderEntities.Find(id);
            if (tempOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(tempOrderEntities);
        }

        // POST: TempOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TempID,OID,Amount,Price")] TempOrderEntities tempOrderEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempOrderEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempOrderEntities);
        }

        // GET: TempOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempOrderEntities tempOrderEntities = db.TempOrderEntities.Find(id);
            if (tempOrderEntities == null)
            {
                return HttpNotFound();
            }
            return View(tempOrderEntities);
        }

        // POST: TempOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TempOrderEntities tempOrderEntities = db.TempOrderEntities.Find(id);
            db.TempOrderEntities.Remove(tempOrderEntities);
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
