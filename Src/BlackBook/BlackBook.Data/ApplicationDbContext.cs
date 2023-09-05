using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookFile> BookFiles { get; set; }
        public DbSet<UserBookProgress> UserBookProgress { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.UserBookProgress)
                .WithOne(ubp => ubp.Book)
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для UserBookProgress

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookFile)
                .WithOne(bf => bf.Book)
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для BookFile
        }
    }
}