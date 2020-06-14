using System.Collections.Generic;

namespace CinemaApplication.Entity.Entities
{
    public class Session : BaseEntity
    {
        public long Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ICollection<VisionMovie> VisionMovies { get; set; }
    }
}
