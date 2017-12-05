namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ismail99 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorum", "Onay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yorum", "Onay");
        }
    }
}
