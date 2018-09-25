using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class TempOrderEntities
    {
    
        private int tempID;
        private int oID;
        private int amount;
        private int price;

        [Key]
        public int TempID { get => tempID; set => tempID = value; }
        public int OID { get => oID; set => oID = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Price { get => price; set => price = value; }
    }
}