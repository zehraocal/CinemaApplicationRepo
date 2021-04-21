using CinemaApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class DetailMovieVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string PosterName { get; set; }
        public string PngBase64 { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ActorName { get; set; }
        public string DirectorName { get; set; }

    }
}
