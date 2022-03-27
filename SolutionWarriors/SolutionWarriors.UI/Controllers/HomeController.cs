using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace SolutionWarriors.UI.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetScorePlayers()
        {
            var userList = new List<Engine.Entitys.UserWinScore>();

            for (int i = 0; i < 10; i++)
            {
                userList.Add(new Engine.Entitys.UserWinScore { 
                    UserId = "4f057839-88c4-477f-8561-77a663488d84",
                    UserNickname = "Player",
                    WinsNumber = i
                });
            }

            var score = userList
                .OrderByDescending(a => a.WinsNumber)
                .Take(5);

            return StatusCode(200, score);
        }
    }
}
