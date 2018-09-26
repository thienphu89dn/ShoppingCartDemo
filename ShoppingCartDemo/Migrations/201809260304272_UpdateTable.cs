namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        CID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OID);
            
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        OID = c.Int(nullable: false),
                        PID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        TempOrderEntities_TempID = c.Int(),
                    })
                .PrimaryKey(t => new { t.OID, t.PID })
                .ForeignKey("dbo.Order", t => t.OID, cascadeDelete: true)
                .ForeignKey("dbo.TempOrder", t => t.TempOrderEntities_TempID)
                .Index(t => t.OID)
                .Index(t => t.TempOrderEntities_TempID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Supplier = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SID);
            
            CreateTable(
                "dbo.TempOrder",
                c => new
                    {
                        TempID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TempID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrder", "TempOrderEntities_TempID", "dbo.TempOrder");
            DropForeignKey("dbo.ProductOrder", "OID", "dbo.Order");
            DropIndex("dbo.ProductOrder", new[] { "TempOrderEntities_TempID" });
            DropIndex("dbo.ProductOrder", new[] { "OID" });
            DropTable("dbo.TempOrder");
            DropTable("dbo.Supplier");
            DropTable("dbo.Product");
            DropTable("dbo.ProductOrder");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
