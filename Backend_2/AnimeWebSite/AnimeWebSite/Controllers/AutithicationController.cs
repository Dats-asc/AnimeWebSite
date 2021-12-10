using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AnimeWebSite.Hashing;
using AnimeWebSite.Models;
using AnimeWebSite.Options;
using AnimeWebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AnimeWebSite.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthController : Controller
    {
        private readonly IOptions<AuthOptions> _options;
        private readonly DBConnection _userDbContext;
        public AuthController(IOptions<AuthOptions> options, DBConnection userDbContext)
        {
            this._options = options;
            _userDbContext = userDbContext;
        }
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Registration([FromForm] Registration registration)
        {
            var user = AuthenticateUser(registration.Login, registration.Password);

            if (user != null)
            {
                var token = Service.GenerateJwt(user);
            }

            user = new Accounts()
            {
                User_id = Guid.NewGuid(),
                Login = registration.Login,
                Password = Hasher.Encrypt(registration.Password),
            };
            _userDbContext.AccountCreate(user);
            return View("LogIn");
        }

        [HttpPost]
        public IActionResult Login([FromForm] Autithication autithication)
        {
            var password = Hasher.Encrypt(autithication.Password);
            var user = AuthenticateUser(autithication.Login, password);
            if (user != null)
            {
                var str = Service.GenerateJwt(user);
                Response.Cookies.Append("str",str,new CookieOptions
                {
                    HttpOnly = true
                });
                return Ok(new
                {
                    message = "success"
                });
            }
            return Unauthorized();
        }
        
        
        private Accounts AuthenticateUser(string login_, string password_)
        {
            return _userDbContext.User.FirstOrDefault(x => x.Login==login_ && x.Password==password_);
        }

        
    }
}