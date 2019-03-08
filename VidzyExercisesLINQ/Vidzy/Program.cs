using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyContext context = new VidzyContext();
            ListOfGenresAndNumberOfVideosTheyIncludeSortedByTheNumberOfVideos(context);
        }

        private static void ListOfGenresAndNumberOfVideosTheyIncludeSortedByTheNumberOfVideos(VidzyContext context)
        {
            var query = from g in context.Genres
                        join v in context.Videos on g.Id equals v.GenreId into gr
                        orderby g.Videos.Count() descending
                        select new
                        {
                            g.Name,
                            VideosCount = gr.Count()
                        };

            foreach (var group in query)
                Console.WriteLine($"{group.Name} ({group.VideosCount})");
        }

        private static void ListOfClassificationsSortedAlphabeticallyAndCountOfVideosInThem(VidzyContext context)
        {
            var query = from v in context.Videos
                        group v by v.Classification into g
                        orderby g.Key.ToString()
                        select g;

            foreach (var group in query)
                Console.WriteLine($"{group.Key} ({group.Count()})");
        }

        private static void AllMoviesGroupedByTheirClassification(VidzyContext context)
        {
            var query = from v in context.Videos
                        group v by v.Classification into g
                        select new
                        {
                            Classification = g.Key.ToString(),
                            Movies = g.OrderBy(m => m.Name)
                        };

            foreach (var group in query)
            {
                Console.WriteLine($"Classification: {group.Classification}");

                foreach (var movie in group.Movies)
                    Console.WriteLine(movie.Name);

                Console.WriteLine();
            }
        }

        private static void AllMoviesProjectedIntoAnAnonymousType_MovieNameAndGenre(VidzyContext context)
        {
            var query = from v in context.Videos
                        select new
                        {
                            MovieName = v.Name,
                            v.Genre
                        };

            foreach (var video in query)
                Console.WriteLine(video.MovieName);
        }

        private static void GoldDramaMoviesSortedByReleaseDate(VidzyContext context)
        {
            var query = from v in context.Videos
                        where v.Classification == Classification.Gold && v.Genre.Name == "Drama"
                        orderby v.ReleaseDate descending
                        select v.Name;

            foreach (var video in query)
                Console.WriteLine(video);
        }

        private static void ActionMovesSortedByName(VidzyContext context)
        {
            var query = from v in context.Videos
                        where v.Genre.Name == "Action"
                        orderby v.Name
                        select v.Name;

            foreach (var video in query)
                Console.WriteLine(video);
        }
    }
}
