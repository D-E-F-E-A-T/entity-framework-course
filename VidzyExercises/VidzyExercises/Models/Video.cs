using System;
using System.Collections.Generic;

namespace VidzyExercises.Models
{
    public class Video
    {
        public Video()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
        public Classification Classification { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
