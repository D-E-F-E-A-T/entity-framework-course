using System.Data.Entity;
using VidzyExercises.EntityConfigurations;
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
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
