﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vidzy.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Video> Videos { get; set; }

        public Genre()
        {
            Videos = new Collection<Video>();
        }
    }
}