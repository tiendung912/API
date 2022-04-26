using dungDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace dungDAL.dungContext
{
    public class dungContext:DbContext
    {
        public dungContext(DbContextOptions<dungContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Movie> Movies { get; set; }
    }
}