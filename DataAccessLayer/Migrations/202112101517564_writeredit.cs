namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writeredit : DbMigration
    {
        public override void Up()//güncellenicek kısım
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 200));
        }
        
        public override void Down()//vazgeçersek bu method çalışır
        {
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
