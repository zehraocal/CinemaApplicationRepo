using System;

namespace CinemaApplication.Entity.ViewModels
{
    public class VisionMovieGetVM
    {
        public long? MovieId { get; set; }
        public long? SessionId { get; set; }
        public long? MovieHouseId { get; set; }
        public string? DisplayDate { get; set; }
    }
}
