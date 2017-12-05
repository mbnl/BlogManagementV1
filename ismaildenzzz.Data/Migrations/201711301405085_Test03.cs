namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test03 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EtiketBlogs", name: "EtiketId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.EtiketBlogs", name: "BlogId", newName: "EtiketId");
            RenameColumn(table: "dbo.EtiketBlogs", name: "__mig_tmp__0", newName: "BlogId");
            RenameIndex(table: "dbo.EtiketBlogs", name: "IX_EtiketId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.EtiketBlogs", name: "IX_BlogId", newName: "IX_EtiketId");
            RenameIndex(table: "dbo.EtiketBlogs", name: "__mig_tmp__0", newName: "IX_BlogId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EtiketBlogs", name: "IX_BlogId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.EtiketBlogs", name: "IX_EtiketId", newName: "IX_BlogId");
            RenameIndex(table: "dbo.EtiketBlogs", name: "__mig_tmp__0", newName: "IX_EtiketId");
            RenameColumn(table: "dbo.EtiketBlogs", name: "BlogId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.EtiketBlogs", name: "EtiketId", newName: "BlogId");
            RenameColumn(table: "dbo.EtiketBlogs", name: "__mig_tmp__0", newName: "EtiketId");
        }
    }
}
