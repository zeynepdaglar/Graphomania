namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        ContentText = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        WriterId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId)
                .Index(t => t.HeadingId)
                .Index(t => t.WriterId);
            
            AddColumn("dbo.Headings", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Headings", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Headings", "CategoryId");
            CreateIndex("dbo.Headings", "WriterId");
            AddForeignKey("dbo.Headings", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            DropColumn("dbo.Headings", "WriterId");
            DropColumn("dbo.Headings", "CategoryId");
            DropTable("dbo.Contents");
        }
    }
}
