using Microsoft.EntityFrameworkCore;

namespace Mission06_Lindsey.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) 
        { 
        }

        public DbSet<AddMovie> addMovies { get; set; }
    }


}
