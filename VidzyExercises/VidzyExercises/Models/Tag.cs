using System.Collections.Generic;

namespace VidzyExercises.Models
{
    public class Tag
    {
        public Tag()
        {
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
