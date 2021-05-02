using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.BL.TokenHandler;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    

    public class LoginController : ControllerBase
    {
        CinemaApplicationContext _context;
        IConfiguration _configuration;
        IBILoginRepository _bILoginRepository;
        public LoginController(CinemaApplicationContext context, IConfiguration configuration, IBILoginRepository bILoginRepository)
        {
            _context = DbContextService.GetDbContext();
            _configuration = configuration;
            _bILoginRepository = bILoginRepository;
        }
        [HttpPost]
        public IActionResult Login(UserLoginVM user)
        {
            User getUser = _context.Users.FirstOrDefault(d => d.Username == user.Username && d.Password == user.Password);

            if (getUser != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(getUser);


                getUser.RefreshToken = token.RefreshToken;
                getUser.RefreshTokenEndDate = token.Expiration.AddSeconds(30);
                _context.SaveChanges();

                return Ok(token);
            }
            return Ok("Kullanıcı adı veya şifre yanlış!");
        }


        [HttpPost]
        public IActionResult AddUser(UserAddVM model)
        {
            _bILoginRepository.Add(model);
            return Ok(true);
        }


        [Authorize]
        public IActionResult Dogrula()
        {
            return Ok(true);
        }
    }
}