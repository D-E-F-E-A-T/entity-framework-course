using System;
using System.Data.Entity;
using System.Linq;
using Vidzy.Models;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VidzyContext())
                RemoveGenre(context, 2, enforceDeletingVideos: true);
        }

        /// <summary>
        /// Add a new video called “Terminator 1” with genre Action, release date 26 Oct, 1984, and Silver 
        /// classification.Ensure the Action genre is not duplicated in the Genres table.
        /// </summary>
        /// <param name="context"></param>
        private static void AddVideo(VidzyContext context)
        {
            context.Videos.Add(new Video
            {
                Name = "Terminator 1",
                GenreId = 2,
                ReleaseDate = new DateTime(1984, 10, 26),
                Classification = Classification.Silver
            });
            context.SaveChanges();
        }

        /// <summary>
        /// Add two tags “classics” and “drama” to the database. Ensure if your method is called twice, 
        /// these tags are not duplicated.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tags"></param>
        private static void AddTags(VidzyContext context, params string[] tags)
        {
            var existingTags = from t in context.Tags
                               where tags.Contains(t.Name)
                               select t.Name;

            foreach (var tag in tags)
                if (!existingTags.Contains(tag))
                    context.Tags.Add(new Tag { Name = tag });

            context.SaveChanges();
        }

        /// <summary>
        /// Add three tags “classics”, “drama” and “comedy” to the video with Id 1 (The Godfather). Ensure 
        /// the “classics” and “drama” tags are not duplicated in the Tags table.Also, ensure that if your 
        /// method is called twice, these tags are not duplicated in VideoTags table.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="videoId"></param>
        /// <param name="tagNames"></param>
        private static void AddTagsToVideo(VidzyContext context, int videoId, params string[] tagNames)
        {
            AddTags(context, tagNames);

            var video = context.Videos.Include(v => v.Tags).Single(v => v.Id == 1);
            var tags = context.Tags.Where(t => tagNames.Contains(t.Name));

            foreach (var tag in tags)
                video.AddTag(tag);

            context.SaveChanges();
        }

        /// <summary>
        /// Remove the “comedy” tag from the the video with Id 1 (The Godfather).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="videoId"></param>
        /// <param name="tagNames"></param>
        private static void RemoveTags(VidzyContext context, int videoId, params string[] tagNames)
        {
            var video = context.Videos.Include(v => v.Tags).Single(v => v.Id == videoId);

            foreach (var tag in tagNames)
                video.RemoveTag(tag);

            context.SaveChanges();
        }

        /// <summary>
        /// Remove the video with Id 1 (The Godfather). 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="videoId"></param>
        private static void RemoveVideo(VidzyContext context, int videoId)
        {
            var video = context.Videos.SingleOrDefault(v => v.Id == videoId);

            if (video == null)
                return;

            context.Videos.Remove(video);
            context.SaveChanges();
        }

        /// <summary>
        /// Remove the genre with Id 2 (Action). Ensure all courses with this genre are deleted 
        /// from the database.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="genreId"></param>
        private static void RemoveGenre(VidzyContext context, int genreId, bool enforceDeletingVideos = false)
        {
            var genre = context.Genres.Include(g => g.Videos)
                                      .SingleOrDefault(g => g.Id == genreId);

            if (genre == null)
                return;

            if (enforceDeletingVideos)
                context.Videos.RemoveRange(genre.Videos);

            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}
