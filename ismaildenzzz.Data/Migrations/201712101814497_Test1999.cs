namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1999 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etiket", "EtiketLink", c => c.String(nullable: false));
            AddColumn("dbo.Kategori", "KategoriLink", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategori", "KategoriLink");
            DropColumn("dbo.Etiket", "EtiketLink");
        }
    }
}
