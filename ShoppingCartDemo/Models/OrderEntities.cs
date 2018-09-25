using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class OrderEntities
    {
        
        private int oID;
        private int cID;
        private List<ProductOrderEntities> listProduct;
        private long totalPrice;
        private DateTime orderDate;

        [Key]
        public int OID { get => oID; set => oID = value; }
        public int CID { get => cID; set => cID = value; }
        public List<ProductOrderEntities> ListProduct { get => listProduct; set => listProduct = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public long TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}