using Library_Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Task = Library_Domain.Task;

namespace LibraryDataAccess
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB ;Initial Catalog = LibraryDatabase ") ;
        }
    }
}