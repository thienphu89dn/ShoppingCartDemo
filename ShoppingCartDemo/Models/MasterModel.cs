namespace ShoppingCartDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MasterModel : DbContext
    {
        public MasterModel()
            : base("name=MasterModel")
        {
        }

        public virtual DbSet<CustomerEntities> CustomerEntities { get; set; }
        public virtual DbSet<OrderEntities> OrderEntities { get; set; }
        public virtual DbSet<ProductEntities> ProductEntities { get; set; }
        public virtual DbSet<ProductOrderEntities> ProductOrderEntities { get; set; }
        public virtual DbSet<SupplierEntities> SupplierEntities { get; set; }
        public virtual DbSet<TempOrderEntities> TempOrderEntities { get; set; }
    }
}