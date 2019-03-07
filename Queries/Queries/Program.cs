using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();

            // Inner Join
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
    }
}
