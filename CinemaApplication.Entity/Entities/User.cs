using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.Entities
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
