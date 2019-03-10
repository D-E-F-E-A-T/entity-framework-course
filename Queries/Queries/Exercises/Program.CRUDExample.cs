using Queries.Core;
using Queries.Core.Domain;
using Queries.Persistence;
using System;
using System.Data.Entity;
using System.Linq;

namespace Queries
{
    partial class Program
    {
        private static class CRUDExample
        {
            public static void ChangeTrackerExample(PlutoContext context)
            {
                // Add an object
                context.Authors.Add(new Author { Name = $"New Author at {DateTime.Now}" });

                // Update an object
                var author = context.Authors.Find(3);
                author.Name = $"Updated author at {DateTime.Now}";

                // Remove an object
                var another = context.Authors.Find(4);
                context.Authors.Remove(another);

                var entries = context.ChangeTracker.Entries();

                foreach (var entry in entries)
                    Console.WriteLine(entry.State);
            }

            public static void RemoveWithoutCascadeDelete(PlutoContext context)
            {
                var author = context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == 2);

                if (author == null)
                {
                    Console.WriteLine("Author is null.");
                    return;
                }

                context.Courses.RemoveRange(author.Courses);
                context.Authors.Remove(author);

                context.SaveChanges();
            }

            public static void RemoveWithCascadeDelete(PlutoContext context)
            {
                var course = context.Courses.Find(6);
                context.Courses.Remove(course);

                context.SaveChanges();
            }

            public static void UpdateExample(PlutoContext context)
            {
                var course = context.Courses.Find(4);
                course.Name = $"New Name at {DateTime.Now}";
                course.AuthorId = 2;

                context.SaveChanges();
            }

            public static void AddExample(PlutoContext context)
            {
                var course = new Course
                {
                    Name = $"New Course at {DateTime.Now}",
                    Description = "New Description",
                    FullPrice = 19.95f,
                    Level = 1,
                    AuthorId = 1
                };

                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
    }
}
