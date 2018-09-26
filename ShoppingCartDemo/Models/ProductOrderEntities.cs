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
        private int pID;
        private int amount;

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OID { get => oID; set => oID = value; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PID { get => pID; set => pID = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}