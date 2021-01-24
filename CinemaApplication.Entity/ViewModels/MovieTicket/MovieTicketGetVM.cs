using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class MovieTicketGetVM
    {
        public int MovieId { get; set; }
        public int MovieHouseId { get; set; }
        public int SessionId { get; set; }
        public string SeatName { get; set; }
    }
}
