namespace Boutique.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StructDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 300),
                        Color = c.String(nullable: false, maxLength: 50),
                        Size = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 300));
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Managers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clients", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ArticleId" });
            DropIndex("dbo.Managers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Clients", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Orders");
            DropTable("dbo.Managers");
            DropTable("dbo.Clients");
            DropTable("dbo.Articles");
        }
    }
}
