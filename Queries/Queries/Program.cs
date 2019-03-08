using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();
        }

        private static void CrossJoinExtensionExample(PlutoContext context)
        {
            var query = context.Authors.SelectMany(a => context.Courses, (a, c) => new
            {
                AuthorName = a.Name,
                CourseName = c.Name
            });

            foreach (var item in query)
                Console.WriteLine($"{item.AuthorName}, {item.CourseName}");
        }

        private static void GroupJoinExtensionExample(PlutoContext context)
        {
            var query = context.Authors.GroupJoin(context.Courses,
                a => a.Id,
                c => c.AuthorId,
                (a, c) => new
                {
                    Author = a,
                    CoursesCount = c.Count()
                });

            foreach (var group in query)
                Console.WriteLine($"{group.Author.Name} ({group.CoursesCount})");
        }

        private static void InnerJoinExtensionExample(PlutoContext context)
        {
            var query = context.Courses.Join(context.Authors,
                c => c.AuthorId,
                a => a.Id,
                (c, a) => new
                {
                    AuthorName = a.Name,
                    CourseName = c.Name,
                });

            foreach (var item in query)
                Console.WriteLine($"{item.AuthorName}, {item.CourseName}");
        }

        private static void GroupExtensionExample(PlutoContext context)
        {
            var query = context.Courses.GroupBy(c => c.Level);

            foreach (var group in query)
            {
                Console.WriteLine($"Level {group.Key} ({group.Count()}):");

                foreach (var course in group)
                    Console.WriteLine($"\t{course.Name}");

                Console.WriteLine();
            }
        }

        private static void DistinctExtensionExample(PlutoContext context)
        {
            var query = context.Courses
                .Where(c => c.Level == 1)
                .SelectMany(c => c.Tags)
                .Distinct();

            foreach (var tag in query)
                Console.WriteLine(tag.Name);
        }

        private static void BasicExtensionsExample(PlutoContext context)
        {
            var query = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Author.Name)
                .Select(c => new
                {
                    CourseName = c.Name,
                    AuthorName = c.Author.Name
                });

            foreach (var item in query)
                Console.WriteLine($"{item.AuthorName}, {item.CourseName}");
        }

        private static void CrossJoinExample(PlutoContext context)
        {
            var query = from a in context.Authors
                        from c in context.Courses
                        select new
                        {
                            AuthorName = a.Name,
                            CourseName = c.Name
                        };

            foreach (var item in query)
                Console.WriteLine($"{item.AuthorName}, {item.CourseName}");
        }

        private static void GroupJoinExample(PlutoContext context)
        {
            var query = from a in context.Authors
                        join c in context.Courses on a.Id equals c.AuthorId into g
                        orderby g.Count() descending, a.Name
                        select new
                        {
                            AuthorName = a.Name,
                            Courses = g
                        };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.AuthorName} ({item.Courses.Count()})");

                foreach (var subitem in item.Courses)
                    Console.WriteLine($"\t{subitem.Name}");

                Console.WriteLine();
            }
        }

        private static void InnerJoinExample(PlutoContext context)
        {
            var query = from c in context.Courses
                        join a in context.Authors on c.AuthorId equals a.Id
                        select new
                        {
                            CourseName = c.Name,
                            AuthorName = a.Name
                        };

            foreach (var obj in query)
                Console.WriteLine($"{obj.AuthorName}, {obj.CourseName}");
        }

        private static void GroupExample(PlutoContext context)
        {
            var query = from c in context.Courses
                        group c by c.Level into g
                        select g;

            foreach (var group in query)
            {
                Console.WriteLine($"Level {group.Key} ({group.Count()})");

                foreach (var course in group)
                    Console.WriteLine($"\t{course.Name}");

                Console.WriteLine();
            }
        }
    }
}
