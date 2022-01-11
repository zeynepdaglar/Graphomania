namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(maxLength: 1000),
                        AboutDetails2 = c.String(maxLength: 100),
                        AboutImage1 = c.String(maxLength: 100),
                        AboutImage2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 50),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        UserEmail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 500),
                        HeadingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        WriterName = c.String(maxLength: 50),
                        WriterSurname = c.String(maxLength: 50),
                        WriterImage = c.String(maxLength: 100),
                        WriterEmail = c.String(maxLength: 100),
                        WriterPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Writers");
            DropTable("dbo.Headings");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.Abouts");
        }
    }
}
