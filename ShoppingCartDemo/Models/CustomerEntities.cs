using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class CustomerEntities
    {
        private int cID;
        private String name;
        private String password;
        private String email;

        [Key]
        public int CID { get => cID; set => cID = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}