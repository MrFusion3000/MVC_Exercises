using Microsoft.AspNetCore.Http;
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

        string Key = "SessionRndNumber";

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

        [HttpGet]
        public IActionResult GuessingGame()
        {
            GuessingGameModel.Win = false;
            int _rndNumber = GuessingGameModel.RndNumb();
            HttpContext.Session.SetInt32(Key, _rndNumber);
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int _guessedNumber)
        {
            GuessingGameModel guessingGame = new GuessingGameModel();
            GuessingGameModel.GuessedNumber = _guessedNumber;
            GuessingGameModel.Message = "";

            GuessingGameModel.RndNumber = (int)HttpContext.Session.GetInt32(Key);

            GuessingGameModel.GuessingGameMethod();

            //const string SessionKeyTime = "_Time";
            //// Requires SessionExtensions from sample download.
            //if (HttpContext.Session.Get<DateTime>(SessionKeyTime) == default)
            //{
            //    HttpContext.Session.Set<DateTime>(SessionKeyTime, currentTime);
            //}

            return View(guessingGame);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
