using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.Entities
{
    public class MovieCasting: BaseEntity
    {
        public long Id { get; set; }
        public long CastingId { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public Casting Casting { get; set; }
    }
}
