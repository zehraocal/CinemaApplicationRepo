﻿using System;
using System.Collections.Generic;

namespace CinemaApplication.Entity.Entities
{
    public class Movie : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string PosterName { get; set; }
        public string PngBase64 { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<VisionMovie> VisionMovies { get; set; }
        public ICollection<MovieCasting> MovieCastings { get; set; }
    }
}
