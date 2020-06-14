using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Entity.Entities
{
    public class VisionMovie : BaseEntity
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long SessionId { get; set; }
        public long MovieHouseId { get; set; }
        public DateTime DisplayDate{ get; set; }
        public double Price { get; set; }
        public Movie Movie { get; set; }
        public Session Session { get; set; }
        public MovieHouse MovieHouse { get; set; }
    }
}
