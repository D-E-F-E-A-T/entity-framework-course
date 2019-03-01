using System.Collections.Generic;

namespace VidzyExercises.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
