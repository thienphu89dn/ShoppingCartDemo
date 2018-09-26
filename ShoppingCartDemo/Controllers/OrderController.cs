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
            // get data from order
            var rs = db.OrderEntities.Join(

                db.ProductEntities.Join(db.ProductOrderEntities, 
                    pro => pro.PID, 
                    proOd => proOd.PID, 
                    (pro, proOd) => new { OID = proOd.OID, PID = proOd.PID, Price = pro.Price, Name = pro.Name, Amount = proOd.Amount}),
                od => od.OID,
                ifPro => ifPro.OID,
                (od, ifPro) => new { OID = ifPro.OID, PID = ifPro.PID, Price = ifPro.Price, Name = ifPro.Name, Amount = ifPro.Amount, CID = od.CID, OrderDate = od.OrderDate, TotalPrice = od.TotalPrice}

                ).OrderBy(p => p.OID);

            // set data order into model
            List<HistoryOrder> listHistoryOrder = new List<HistoryOrder>();
            HistoryOrder historyOrder;
            List<HistoryProduct> listProduct;
            HistoryProduct product;
            

            var listRs = rs.ToList();
            int tempOID = 0;
            foreach (var item in listRs)
            {
                if (tempOID != item.OID)
                {
                    tempOID = item.OID;

                    historyOrder = new HistoryOrder();

                    historyOrder.CID = item.CID;
                    historyOrder.OID = item.OID;
                    historyOrder.OrderDate = item.OrderDate;
                    historyOrder.TotalPrice = item.TotalPrice;

                    listProduct = new List<HistoryProduct>();
                    historyOrder.listProduct = listProduct;

                    listHistoryOrder.Add(historyOrder);
                }

                foreach (HistoryOrder i in listHistoryOrder)
                {
                    product = new HistoryProduct();

                    if (i.OID == item.OID)
                    {
                        product.Amount = item.Amount;
                        product.Name = item.Name;
                        product.PID = item.PID;
                        product.Price = item.Price;
                        i.listProduct.Add(product);
                    }
                    
                }
                
            }
            
            return View(listHistoryOrder);
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

        [HttpPost]
        public JsonResult Create(int PID)
        {
            // get info of product
            ProductEntities rs = db.ProductEntities.Where(p => p.PID == PID).FirstOrDefault();
            int price = rs.Price;

            // add order
            OrderEntities newRecord = new OrderEntities();
            newRecord.OrderDate = DateTime.Now;
            newRecord.TotalPrice = price;
            newRecord.CID = 1;
            db.OrderEntities.Add(newRecord);
            db.SaveChanges();

            // get ID order
            int ID = newRecord.OID;

            // if add order successfully
            if (ID > 0)
            {
                // add product of order
                ProductOrderEntities productOrderEntities = new ProductOrderEntities();
                productOrderEntities.OID = ID;
                productOrderEntities.PID = PID;
                productOrderEntities.Amount = 1;
                db.ProductOrderEntities.Add(productOrderEntities);
                db.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            
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
        public ActionResult Edit([Bind(Include = "OID,CID,OrderDate,TotalPrice")] OrderEntities orderEntities)
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
