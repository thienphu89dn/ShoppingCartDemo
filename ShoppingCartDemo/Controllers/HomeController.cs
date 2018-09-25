using ShoppingCartDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Controllers
{
    public class HomeController : Controller
    {
        private MasterModel db = new MasterModel();

        public ActionResult Index()
        {
            return View(db.ProductEntities.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}