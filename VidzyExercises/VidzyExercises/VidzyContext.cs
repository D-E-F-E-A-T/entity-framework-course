using System.Data.Entity;
using VidzyExercises.Models;

namespace VidzyExercises
{
    public class VidzyContext : DbContext
    {
        public VidzyContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
