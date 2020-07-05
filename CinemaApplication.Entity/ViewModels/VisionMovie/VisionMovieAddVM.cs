using CinemaApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
   public class VisionMovieAddVM
    {
        public long MovieId { get; set; }
        public long SessionId { get; set; }
        public long MovieHouseId { get; set; }
        public DateTime DisplayDate { get; set; }
        public double Price { get; set; }
    }
    
}
