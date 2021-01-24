using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BISessionRepository : BlRepository<Session>, IBISessionRepository
    {
        CinemaApplicationContext _context;
        public BISessionRepository( IMapper mappingProfile) : base(mappingProfile)
        {
            _context = DbContextService.GetDbContext();
        }

        public List<Session> GetWhereSessionList(SessionGetVM model)
        {
            var sessions = GetAll().OrderBy(x => x.StartTime).ToList();
            if (!string.IsNullOrEmpty(model.StartTime))
            {
                sessions = GetWhere(y => y.StartTime.Contains(model.StartTime)).ToList();
            }
            return sessions;
        }
        public override bool Add<TAddVM>(TAddVM model)
        {
            var sessionAddParam = model as SessionAddVM;
            sessionAddParam.StartTime = DateTime.Parse(sessionAddParam.StartDate).ToShortTimeString();
            return base.Add(sessionAddParam);
        }

        public List<DropDownListVM> GetVisionMovieDropDownList(MovieTicketGetSession model)
        {
            var result = GetAllWithType<DropDownListVM>().Where(p => _context.Set<VisionMovie>().Where(a => a.MovieId == model.MovieId && a.MovieHouseId== model.VisionMovieId).ToList().Any(p2 => p2.SessionId == p.Value)).ToList();
            return result;
        }
    }
}
