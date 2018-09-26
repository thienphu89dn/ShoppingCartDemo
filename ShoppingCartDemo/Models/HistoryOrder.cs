using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class HistoryOrder
    {
        public int OID { get; set; }
        public long TotalPrice { get; set; }
        public int CID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<HistoryProduct> listProduct { get; set; }
    }
}