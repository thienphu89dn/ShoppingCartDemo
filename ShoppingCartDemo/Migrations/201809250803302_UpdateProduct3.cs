namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductEntities",
                c => new
                {
                    PID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Supplier = c.String(),
                    Price = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PID);
        }
        
        public override void Down()
        {
        }
    }
}
