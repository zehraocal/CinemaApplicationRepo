using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.Entities
{
    public class Casting : BaseEntity
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCasting> MovieCastings { get; set; }

    }
}
