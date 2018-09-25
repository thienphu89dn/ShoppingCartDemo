using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    [Table("TempOrder")]
    public class TempOrderEntities
    {

        private int tempID;
        private List<ProductOrderEntities> listProduct;

        [Key]
        public int TempID { get => tempID; set => tempID = value; }
        public List<ProductOrderEntities> ListProduct { get => listProduct; set => listProduct = value; }
    }
}