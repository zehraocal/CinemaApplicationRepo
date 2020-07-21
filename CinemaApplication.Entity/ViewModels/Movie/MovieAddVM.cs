using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class MovieAddVM
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterName { get; set; }
    }
}
