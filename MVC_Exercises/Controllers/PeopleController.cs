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
            PeopleViewModel.TempSearchList.Clear();

            if (PeopleViewModel.ListPeople.Count == 0)
            {
                PeopleViewModel.CreatePeopleList();
            }
            PeopleViewModel model = new PeopleViewModel
            {
                TempList = PeopleViewModel.ListPeople
            };

            return View(model);
        }        

        [HttpPost]
        public IActionResult PeopleIndex(string searchSubject, PeopleViewModel model)
        {
            if (searchSubject != null) 
            { 
                PeopleViewModel.SearchPeopleList(searchSubject);
                model.TempList = PeopleViewModel.TempSearchList;
            }
            else
            {
                PeopleViewModel.Message = "";
                PeopleViewModel.Message2 = "";

                PeopleViewModel.TempSearchList.Clear();
                model.TempList = PeopleViewModel.ListPeople;
            }

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
            PeopleViewModel.ListPeople.Add(model);
            PeopleViewModel.NewId++;

            return RedirectToAction("PeopleIndex");
        }

        public IActionResult Delete(int Id)
        {
            if (Id != 0) 
            {
                var people = PeopleViewModel.ListPeople.Find(x => x.Id == Id);
                PeopleViewModel.ListPeople.Remove(people);
            }
            else
            {
                PeopleViewModel.Message = "Something went wrong. No Id found.";
            }

            return RedirectToAction("PeopleIndex");
        }

        public IActionResult SortAlpha(/*PeopleViewModel model,*/ string _sortCriteria)
        {
            if (_sortCriteria == "Name")
            {
                PeopleViewModel.OrderOrderName = !PeopleViewModel.OrderOrderName;
                PeopleViewModel.SortListName();

                //model.TempList = PeopleViewModel.TempSearchList;
            }

            if (_sortCriteria == "City")
            {
                PeopleViewModel.OrderOrderCity = !PeopleViewModel.OrderOrderCity;
                PeopleViewModel.SortListCity();

               // model.TempList = PeopleViewModel.TempSearchList;
            }

            return View("PeopleIndex");
        }
    }
}
