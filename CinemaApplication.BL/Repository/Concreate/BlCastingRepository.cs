using AutoMapper;
using CinemaApplication.Entity.Entities;
using CinemaApplication.BL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlCastingRepository : BlRepository<Casting>, IBlCastingRepository
    {
        public BlCastingRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
    }
}
