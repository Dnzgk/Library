using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Web.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Assignment> Assignments { get; set; }        
        public DbSet<Contact> Contacts { get; set; }        
        public DbSet<ContactMessage> ContactMessages { get; set; }        
        public DbSet<MainPage> MainPages { get; set; }        
        public DbSet<Project> Projects { get; set; }        
        public DbSet<Skill> Skills { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
            "Server=DENIZSURFACE;Database=LibraryDb;" +
            "TrustServerCertificate=True;Trusted_Connection=True;Encrypt=False"
               );
            }

            base.OnConfiguring(optionsBuilder);
        }

    }

    

    
}
