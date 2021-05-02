using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
   public class BILoginRepository : BlRepository<User>, IBILoginRepository
    {
        public BILoginRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
    }
}

