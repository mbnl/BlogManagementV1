namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test102 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blog", "SeoLink", c => c.String());
            AlterColumn("dbo.Blog", "Hit", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blog", "Hit", c => c.Int(nullable: false));
            AlterColumn("dbo.Blog", "SeoLink", c => c.String(nullable: false));
        }
    }
}
