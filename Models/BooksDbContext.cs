using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
namespace BookStoreMySQL.Models
{
    public class BooksDbContext:DbContext
    {

        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {
            
        }

        public DbSet<Book> Book { get; set; }        

    }
}