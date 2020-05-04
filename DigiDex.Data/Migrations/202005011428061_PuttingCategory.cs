namespace DigiDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuttingCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Card", "CategoryId", c => c.Int());
            CreateIndex("dbo.Card", "CategoryId");
            AddForeignKey("dbo.Card", "CategoryId", "dbo.Category", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "CategoryId", "dbo.Category");
            DropIndex("dbo.Card", new[] { "CategoryId" });
            DropColumn("dbo.Card", "CategoryId");
        }
    }
}
