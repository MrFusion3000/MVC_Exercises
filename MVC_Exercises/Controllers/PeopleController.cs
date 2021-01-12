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

        public IActionResult PeopleIndex()
        {
            if (PeopleViewModel.listPeople.Count == 0)
            {
                PeopleViewModel.CreatePeopleList();
            }
            PeopleViewModel model = new PeopleViewModel();
            model.tempList = PeopleViewModel.listPeople;

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PeopleViewModel model)
        {
            model.Id = PeopleViewModel.NewId;
            PeopleViewModel.listPeople.Add(model);
            PeopleViewModel.NewId++;

            return RedirectToAction("PeopleIndex");
        }

        public IActionResult Delete(int Id)
        {
            var people = PeopleViewModel.listPeople.Find(x => x.Id == Id);
            PeopleViewModel.listPeople.Remove(people);

            return View("PeopleIndex");
        }

        [HttpPostAttribute]
        public IActionResult PeopleIndex (string searchSubject, PeopleViewModel tempList)
        {
            tempList = PeopleViewModel.listPeople.Find(x => x.Name == searchSubject);
            

            return View(tempList);
        }
    }
}
