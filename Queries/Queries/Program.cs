using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();

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
