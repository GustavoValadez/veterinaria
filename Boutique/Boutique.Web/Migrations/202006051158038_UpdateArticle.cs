namespace Boutique.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Article_Id", c => c.Int());
            CreateIndex("dbo.Clients", "Article_Id");
            AddForeignKey("dbo.Clients", "Article_Id", "dbo.Articles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Clients", new[] { "Article_Id" });
            DropColumn("dbo.Clients", "Article_Id");
        }
    }
}
