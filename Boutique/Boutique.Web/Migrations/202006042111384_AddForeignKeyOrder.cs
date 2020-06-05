namespace Boutique.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ClientId");
            AddForeignKey("dbo.Orders", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropColumn("dbo.Orders", "ClientId");
        }
    }
}
