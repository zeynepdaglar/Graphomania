namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CantactDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 1000));
            DropColumn("dbo.Contacts", "CantactDate");
        }
    }
}
