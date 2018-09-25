using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    [Table("ProductOrder")]
    public class ProductOrderEntities
    {
        
        private int oID;
        private string pID;
        private int amount;

        [Key]
        public int OID { get => oID; set => oID = value; }
        public string PID { get => pID; set => pID = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}