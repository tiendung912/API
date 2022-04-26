using dungDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace dungDAL.dungContext
{
    public class dungDbContext:DbContext
    {
        public dungDbContext(DbContextOptions<dungDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Movie> Movies { get; set; }
    }
}