using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class HistoryProduct
    {
        public int PID { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}