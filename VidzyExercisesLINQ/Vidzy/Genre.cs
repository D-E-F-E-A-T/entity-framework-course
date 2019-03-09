using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vidzy
{
    public class Genre
    {
        public Genre()
        {
            Videos = new HashSet<Video>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Video> Videos { get; set; }        
    }
}