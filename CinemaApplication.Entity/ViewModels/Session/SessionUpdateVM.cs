 using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Entity.ViewModels
{
    public class SessionUpdateVM: UpdateVMBase
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
