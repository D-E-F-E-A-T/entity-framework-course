using Queries.Persistence;

namespace Queries
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // Example 1
                var course = unitOfWork.Courses.Get(1);

                // Example 2
                var coursesWithAuthors = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example 3
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                unitOfWork.Courses.RemoveRange(author.Courses);
                unitOfWork.Authors.Remove(author);

                unitOfWork.Complete();
            }
        }
    }
}
