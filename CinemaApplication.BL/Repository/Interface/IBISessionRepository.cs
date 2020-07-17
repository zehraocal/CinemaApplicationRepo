using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Interface
{
    public interface IBISessionRepository: IBlRepository<Session>
    {
        List<Session> GetWhereSessionList(SessionGetVM model);
        //string SessionConvertType(SessionAddVM model);
    }
}
