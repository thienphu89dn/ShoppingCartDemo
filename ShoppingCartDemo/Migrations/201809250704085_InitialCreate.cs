namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerEntities",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        CID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderDelivery = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OID);
            
            CreateTable(
                "dbo.ProductOrderEntities",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        PID = c.String(),
                        Amount = c.Int(nullable: false),
                        OrderEntities_OID = c.Int(),
                    })
                .PrimaryKey(t => t.OID)
                .ForeignKey("dbo.OrderEntities", t => t.OrderEntities_OID)
                .Index(t => t.OrderEntities_OID);
            
            CreateTable(
                "dbo.ProductEntities",
                c => new
                    {
                        PID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Supplier = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.SupplierEntities",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SID);
            
            CreateTable(
                "dbo.TempOrderEntities",
                c => new
                    {
                        TempID = c.Int(nullable: false, identity: true),
                        OID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrderEntities", "OrderEntities_OID", "dbo.OrderEntities");
            DropIndex("dbo.ProductOrderEntities", new[] { "OrderEntities_OID" });
            DropTable("dbo.TempOrderEntities");
            DropTable("dbo.SupplierEntities");
            DropTable("dbo.ProductEntities");
            DropTable("dbo.ProductOrderEntities");
            DropTable("dbo.OrderEntities");
            DropTable("dbo.CustomerEntities");
        }
    }
}
