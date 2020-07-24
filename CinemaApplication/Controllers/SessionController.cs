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

        [HttpPost]
        public IActionResult GetWhereSessionList(SessionGetVM model)
        { 
            return Ok(_bISessionRepository.GetWhereSessionList(model));
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

        [HttpPost]
        public IActionResult GetVisionMovieDropDownList(MovieTicketGetSession model)
        {
            return Ok(_bISessionRepository.GetVisionMovieDropDownList(model));
        }

    }
}