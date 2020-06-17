using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class MovieHouseUpdateVM : UpdateVMBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
