using System;

namespace DbFirstWorkflow
{
    public enum Level : byte
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course
            {
                Level = Level.Advanced
            };
        }
    }
}
