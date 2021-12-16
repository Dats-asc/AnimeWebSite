using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AnimeWebApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnimeWebSite.Models;
using Microsoft.AspNetCore.Http;

namespace AnimeWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private Tools.Tools Tools;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _logger = logger;
            _db = context;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            Tools = new Tools.Tools(context, jWTAuthenticationManager);
        }

        public IActionResult Index()
        {
            var user = Tools.FindUserByToken(Request); 
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}