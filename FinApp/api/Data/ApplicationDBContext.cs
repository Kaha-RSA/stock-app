using FinApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.api.Data
{
    // This class represents the application's database context, which is responsible for interacting with the underlying database.
    public class ApplicationDBContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter and passes it to the base class constructor.
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            // The constructor doesn't have any additional logic, but it's responsible for passing options to the base class.
        }

        // DbSet represents a collection of entities (database table) for the Stock model.
        public DbSet<Stock> Stocks { get; set; }

        // DbSet represents a collection of entities (database table) for the Comment model.
        public DbSet<Comment> Comments { get; set; }
    }
}
