using Microsoft.AspNetCore.Mvc;
using MVC_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult DisplayPeopleDetails()
        {
            List<PeopleModel> listCustomer = new List<PeopleModel>();
            PeopleModel people = new PeopleModel();

            people.Name = "Sverre Bumpa Jr";
            people.Phone = 087565133;
            people.City = "Stockholm";
            listCustomer.Add(people);

            people = new PeopleModel();
            people.Name = "Alf-Alfa Betasson";
            people.Phone = 0760100200;
            people.City = "Örebro";
            listCustomer.Add(people);


            return View(listCustomer);
        }
    }
}
