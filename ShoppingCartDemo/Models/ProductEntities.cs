using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    [Table("Product")]
    public class ProductEntities
    {
        
        private int pID;
        private string name;
        private string description;
        private string supplier;
        private int price;

        [Key]
        public int PID { get => pID; set => pID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public int Price { get => price; set => price = value; }
    }
}