namespace DigiDex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeckId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "DeckId" });
            AlterColumn("dbo.Card", "DeckId", c => c.Int());
            CreateIndex("dbo.Card", "DeckId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "DeckId" });
            AlterColumn("dbo.Card", "DeckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Card", "DeckId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId", cascadeDelete: true);
        }
    }
}
