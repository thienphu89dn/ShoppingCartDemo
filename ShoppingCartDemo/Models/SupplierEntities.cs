using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class SupplierEntities
    {
        private int sID;
        private string name;

        [Key]
        public int SID { get => sID; set => sID = value; }
        public string Name { get => name; set => name = value; }
    }
}