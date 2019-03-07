using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();
            GroupJoinExample(context);
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
