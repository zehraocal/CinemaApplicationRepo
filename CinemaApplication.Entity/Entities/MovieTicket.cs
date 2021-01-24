using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.Entities
{
    public class MovieTicket: BaseEntity
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public int MovieHouseId { get; set; }
        public int SessionId { get; set; }
        public string SeatName { get; set; }
    }
}
