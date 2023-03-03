using bookish.Models;
using Microsoft.EntityFrameworkCore;
using bookish;

namespace bookish
{
    public class BookishContext : DbContext
    {
        // Put all the tables you want in your database here
        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Checkout> Checkout { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=Bookish1;");
        }
    }
}