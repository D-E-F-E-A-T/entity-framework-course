namespace CodeFirstExistingDatabase.Migrations
{
    using CodeFirstExistingDatabase.Models;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlutoContext context)
        {
            context.Authors.AddOrUpdate(
                a => a.Name,
                new Author[] 
                {
                    new Author
                    {
                        Name = "Author 1",
                        Courses = new Collection<Course>
                        {
                            new Course { Name = "Course for Author 1", Description = "Some description" }
                        }
                    }
                });
        }
    }
}
