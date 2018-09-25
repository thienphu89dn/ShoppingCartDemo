namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductEntities");
            AlterColumn("dbo.ProductEntities", "PID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductEntities", "PID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductEntities");
            AlterColumn("dbo.ProductEntities", "PID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProductEntities", "PID");
        }
    }
}
