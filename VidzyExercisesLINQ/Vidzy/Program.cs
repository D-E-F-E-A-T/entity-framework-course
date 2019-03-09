using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();
            
            // Eager loading solution
            //var videos = context.Videos.Include(v => v.Genre);

            // Explicit loading solution
            var videos = context.Videos;
            var genresId = videos.Select(v => v.GenreId).Distinct();

            context.Genres.Where(g => genresId.Contains(g.Id)).Load();

            foreach (var video in videos)
                Console.WriteLine($"[{video.Genre.Name}, {video.Name}]");            
        }
    }
}
