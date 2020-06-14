using System.Collections.Generic;

namespace CinemaApplication.Entity.Entities
{
    public class MovieHouse : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<VisionMovie> VisionMovies { get; set; }
    }
}
