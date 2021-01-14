using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Models
{
    public class PeopleViewModel
    {
        [Required]        
        public int Id { get; set; }
        public static int NewId { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [Required]
        //[DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public int Phone { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        [DisplayName("Home City")]
        public string City { get; set; }

        public static List<PeopleViewModel> ListPeople { get; set; } = new List<PeopleViewModel>();
        public List<PeopleViewModel> TempList { get; set; } = new List<PeopleViewModel>();
        public static List<PeopleViewModel> TempSearchList { get; set; } = new List<PeopleViewModel>();

        public static string Message { get; set; }
        public static string Message2 { get; set; }

        public static bool OrderOrderName { get; set; }
        public static bool OrderOrderCity { get; set; }

        public static void CreatePeopleList()
        {
            ListPeople.Add(new PeopleViewModel { Id = 1, Name = "Sverre Bumpa Jr", Phone = 087565133, City = "Stockholm" });
            ListPeople.Add(new PeopleViewModel { Id = 2, Name = "Alf-Alfa Betasson", Phone = 0760100200, City = "Örebro" });
            ListPeople.Add(new PeopleViewModel { Id = 3, Name = "Förste Walter", Phone = 08212325, City = "Reykjavik" });

            NewId = ListPeople.Count + 1;
        }
    
        public static void SearchPeopleList(string _searchSubject)
        {
            IEnumerable<PeopleViewModel> tempSearch = from p in PeopleViewModel.ListPeople
                                                      where p.Name == _searchSubject
                                                      select p;
            
            foreach (var item in tempSearch)
            {
                TempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City});
            }

            IEnumerable<PeopleViewModel> tempSearch2 = from p in PeopleViewModel.ListPeople
                                                       where p.City == _searchSubject
                                                       select p;

            foreach (var item in tempSearch2)
            {
                TempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City });
            }

            if (TempSearchList.Count == 0)
            {
                Message = "The name or city does not exist in the list.";
                Message2 = "Do a new search. (Leave empty to show whole list.)";

            }
        }

        public static void SortListName()
        {
            TempSearchList.Clear();
            IEnumerable<PeopleViewModel> sortOrder;

            if (OrderOrderName == true)
            {
                sortOrder = ListPeople.OrderBy(p => p.Name);
            }
            else
            {
                sortOrder = ListPeople.OrderByDescending(p => p.Name);
            }
           
            foreach (var item in sortOrder)
            {
                TempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City });
            }
        }

        public static void SortListCity()
        {
            TempSearchList.Clear();
            IEnumerable<PeopleViewModel> sortOrder;

            if (OrderOrderCity == true)
            {                
                //orderAscending = ListPeople.OrderByDescending(p => p.City);
                sortOrder = from p in PeopleViewModel.ListPeople
                            orderby p.City
                            select p;
            }
            else
            {
                //orderAscending = ListPeople.OrderByDescending(p => p.City);
                sortOrder = from p in PeopleViewModel.ListPeople
                            orderby p.City descending
                            select p;
                }            

            foreach (var item in sortOrder)
            {
                TempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City });
            }
        }
    }

}
