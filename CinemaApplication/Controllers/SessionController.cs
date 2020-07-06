using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        IBISessionRepository _bISessionRepository;
        public SessionController(IBISessionRepository bISessionRepository)
        {
            _bISessionRepository = bISessionRepository;
        }

        //public IActionResult GetSession()
        //{
        //    return Ok(_bISessionRepository.GetAll());
        //}

        [HttpPost]
        public IActionResult GetSession(SessionGetVM model)
        {
            var sessions = _bISessionRepository.GetAll().OrderBy(x => x.StartTime).ToList();
            if (!string.IsNullOrEmpty(model.StartTime))
            {
                sessions = _bISessionRepository.GetWhere(y => y.StartTime.Contains(model.StartTime)).ToList();
            }
            return Ok(sessions);
        }
        [HttpPost]
        public IActionResult AddSession(SessionAddVM model)
        {
            _bISessionRepository.Add(model);
            return Ok(true);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSession(long id)
        {
            _bISessionRepository.Remove(id);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult UpdateSession(SessionUpdateVM param)
        {
            return Ok(_bISessionRepository.Update(param));
        }

        [HttpGet]
        public IActionResult GetDropDownList()
        {
            return Ok(_bISessionRepository.GetAllWithType<DropDownListVM>());
        }
    }
}