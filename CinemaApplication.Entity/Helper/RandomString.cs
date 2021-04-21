﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.Entity.Helper
{
   public class RandomString
    {
        private static Random random = new Random();
        public static string CreateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
