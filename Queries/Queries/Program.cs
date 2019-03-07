using Queries.Models;
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();

            // LINQ syntax
            var query = from course in context.Courses
                        where course.Name.ToLower().Contains("c#")
                        orderby course.Name
                        select course;

            foreach (Course course in query)
                Console.WriteLine(course.Name);

            // Extension methods
            var courses = context.Courses
                .Where(course => course.Name.ToLower().Contains("c#"))
                .OrderBy(course => course.Name);

            foreach (Course course in courses)
                Console.WriteLine(course.Name);
        }
    }
}
