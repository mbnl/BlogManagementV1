namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "SeoLink", c => c.String(nullable: false));
            AddColumn("dbo.Blog", "Hit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "Hit");
            DropColumn("dbo.Blog", "SeoLink");
        }
    }
}
