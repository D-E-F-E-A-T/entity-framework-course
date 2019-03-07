using System.Data.Entity.ModelConfiguration;
using VidzyExercises.Models;

namespace VidzyExercises.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
