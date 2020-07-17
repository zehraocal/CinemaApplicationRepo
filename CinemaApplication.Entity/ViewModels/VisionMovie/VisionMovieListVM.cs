using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class VisionMovieListVM
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long SessionId { get; set; }
        public long MovieHouseId { get; set; }
        public DateTime DisplayDate { get; set; }
        public double Price { get; set; }

        public string MovieName { get; set; }
        public string MovieHouseName { get; set; }
        public string SessionStartTime { get; set; }
        public int Duration { get; set; }

    }
}
