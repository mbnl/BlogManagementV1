namespace ismaildenzzz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ismail07 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adsoyad = c.String(nullable: false, maxLength: 255),
                        KullaniciAdi = c.String(nullable: false, maxLength: 16),
                        Sifre = c.String(nullable: false, maxLength: 16),
                        KayitTarihi = c.DateTime(nullable: false),
                        Mail = c.String(nullable: false),
                        AktifMi = c.Boolean(nullable: false),
                        Rol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.Rol_ID);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false),
                        KisaAciklama = c.String(nullable: false),
                        Icerik = c.String(nullable: false),
                        SeoAnahtarlari = c.String(maxLength: 200),
                        SeoAciklama = c.String(maxLength: 250),
                        YuklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                        Resim = c.String(),
                        KategoriID = c.Int(nullable: false),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admin", t => t.AdminID, cascadeDelete: true)
                .ForeignKey("dbo.Kategori", t => t.KategoriID, cascadeDelete: true)
                .Index(t => t.KategoriID)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.Etiket",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EtiketAdi = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yorum",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adsoyad = c.String(nullable: false, maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 100),
                        Site = c.String(maxLength: 100),
                        YorumMesaj = c.String(nullable: false),
                        Blog_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blog", t => t.Blog_ID)
                .Index(t => t.Blog_ID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IP = c.String(),
                        Adsoyad = c.String(nullable: false, maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 100),
                        Konu = c.String(maxLength: 100),
                        Mesaj = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EtiketBlogs",
                c => new
                    {
                        EtiketId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EtiketId, t.BlogId })
                .ForeignKey("dbo.Blog", t => t.EtiketId, cascadeDelete: true)
                .ForeignKey("dbo.Etiket", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.EtiketId)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admin", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.Yorum", "Blog_ID", "dbo.Blog");
            DropForeignKey("dbo.Blog", "KategoriID", "dbo.Kategori");
            DropForeignKey("dbo.EtiketBlogs", "BlogId", "dbo.Etiket");
            DropForeignKey("dbo.EtiketBlogs", "EtiketId", "dbo.Blog");
            DropForeignKey("dbo.Blog", "AdminID", "dbo.Admin");
            DropIndex("dbo.EtiketBlogs", new[] { "BlogId" });
            DropIndex("dbo.EtiketBlogs", new[] { "EtiketId" });
            DropIndex("dbo.Yorum", new[] { "Blog_ID" });
            DropIndex("dbo.Blog", new[] { "AdminID" });
            DropIndex("dbo.Blog", new[] { "KategoriID" });
            DropIndex("dbo.Admin", new[] { "Rol_ID" });
            DropTable("dbo.EtiketBlogs");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Rol");
            DropTable("dbo.Yorum");
            DropTable("dbo.Kategori");
            DropTable("dbo.Etiket");
            DropTable("dbo.Blog");
            DropTable("dbo.Admin");
        }
    }
}
