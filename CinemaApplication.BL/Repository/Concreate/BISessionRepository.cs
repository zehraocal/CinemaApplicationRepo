using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BISessionRepository: BlRepository<Session>, IBISessionRepository
    {
        public BISessionRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
    }
}
