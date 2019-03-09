using Queries.EntityConfigurations;
using Queries.Models;
using System.Data.Entity;

namespace Queries
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base("name=PlutoContext")
        {
            // Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
