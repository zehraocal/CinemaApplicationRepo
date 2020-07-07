using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BISessionRepository: BlRepository<Session>, IBISessionRepository
    {
        public BISessionRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
        public List<Session> GetSession(SessionGetVM model)
        {
            var sessions = GetAll().OrderBy(x => x.StartTime).ToList();
            if (!string.IsNullOrEmpty(model.StartTime))
            {
                sessions = GetWhere(y => y.StartTime.Contains(model.StartTime)).ToList();
            }
            return sessions;
        }
    }
}
