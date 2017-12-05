using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Blog>().
                HasMany<Etiket>(c => c.Etikets).
                WithMany(p => p.Blogs).
                Map(
                    m =>
                    {
                        m.MapLeftKey("BlogId");
                        m.MapRightKey("EtiketId");
                        m.ToTable("EtiketBlogs");
                    });

            modelBuilder.Entity<Blog>().HasRequired<Kategori>(o => o.Kategori).WithMany(o => o.Blogs).HasForeignKey(o => o.KategoriID);
            modelBuilder.Entity<Blog>().HasRequired<Admin>(o => o.Admin).WithMany(o => o.Blogs).HasForeignKey(o => o.AdminID);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
