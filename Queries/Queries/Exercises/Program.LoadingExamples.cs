﻿using Queries.Persistence;
using System;
using System.Data.Entity;
using System.Linq;

namespace Queries
{
    partial class Program
    {
        private static class LoadingExamples
        {
            public static void ExplicitLoadingSample(PlutoContext context)
            {
                // Explicit Loading
                var author = context.Authors.Single(a => a.Id == 1);

                // MSDN way
                context.Entry(author).Collection(a => a.Courses).Load();

                // Mosh way
                context.Courses.Where(c => c.AuthorId == author.Id).Load();

                foreach (var course in author.Courses)
                    Console.WriteLine(course.Name);
            }

            public static void EagerLoadingExample(PlutoContext context)
            {
                // Eager Loading
                var courses = context.Courses.Include(c => c.Author);

                // For single properties
                //var foo = context.Courses.Include(c => c.Author.Name);

                // For collection properties
                //var foo = context.Courses.Include(c => c.Tags.Select(t => t.Name));

                foreach (var course in courses)
                    Console.WriteLine($"[{course.Author.Id}, {course.Author.Name}, {course.Name}]");
            }
        }
    }
}
