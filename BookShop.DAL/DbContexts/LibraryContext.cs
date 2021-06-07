using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL
{
    /// <summary>
    /// DbContext for Book Shop SQL Database
    /// </summary>
    internal class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QOG59O9;Initial Catalog=LibraryDB;Integrated Security=True")
                .EnableSensitiveDataLogging();
        }
    }
}
