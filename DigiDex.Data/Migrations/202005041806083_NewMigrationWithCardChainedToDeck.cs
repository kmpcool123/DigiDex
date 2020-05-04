namespace DigiDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrationWithCardChainedToDeck : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "DeckId" });
            RenameColumn(table: "dbo.Card", name: "CategoryId", newName: "Category_CategoryId");
            RenameIndex(table: "dbo.Card", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            AlterColumn("dbo.Card", "DeckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Card", "DeckId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "DeckId" });
            AlterColumn("dbo.Card", "DeckId", c => c.Int());
            RenameIndex(table: "dbo.Card", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Card", name: "Category_CategoryId", newName: "CategoryId");
            CreateIndex("dbo.Card", "DeckId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId");
        }
    }
}
