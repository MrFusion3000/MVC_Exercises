using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;        

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(int _bodyTemp, string _message)
        {
            FeverCheckModel fever = new FeverCheckModel();
            FeverCheckModel.BodyTemp = _bodyTemp;
            FeverCheckModel.Message = _message;

            FeverCheckModel.FeverCheckMethod(_bodyTemp);

            return View(fever);
        }

        public IActionResult GuessingGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int _guessedNumber, string _message, int _rndNumber)
        {
            GuessingGameModel guessingGame = new GuessingGameModel();
            GuessingGameModel.GuessedNumber = _guessedNumber;
            GuessingGameModel.Message = _message;
            GuessingGameModel.RndNumber = _rndNumber;

            GuessingGameModel.GuessingGameMethod(_guessedNumber);

            return View(guessingGame);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
