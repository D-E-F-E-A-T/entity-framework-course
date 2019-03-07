using System.Data.Entity.ModelConfiguration;
using VidzyExercises.Models;

namespace VidzyExercises.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
