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

        public static List<PeopleViewModel> listPeople { get; set; } = new List<PeopleViewModel>();
        public List<PeopleViewModel> tempList { get; set; } = new List<PeopleViewModel>();
        public static List<PeopleViewModel> tempSearchList { get; set; } = new List<PeopleViewModel>();

        public static string Message { get; set; }
        public static string Message2 { get; set; }

        public static void CreatePeopleList()
        {
            listPeople.Add(new PeopleViewModel { Id = 1, Name = "Sverre Bumpa Jr", Phone = 087565133, City = "Stockholm" });
            listPeople.Add(new PeopleViewModel { Id = 2, Name = "Alf-Alfa Betasson", Phone = 0760100200, City = "Örebro" });
            listPeople.Add(new PeopleViewModel { Id = 3, Name = "Förste Walter", Phone = 08212325, City = "Reykjavik" });

            NewId = listPeople.Count + 1;
        }
    
        public static void SearchPeopleList(string _searchSubject)
        {
            IEnumerable<PeopleViewModel> tempSearch = from p in PeopleViewModel.listPeople
                                                   where p.Name == _searchSubject
                                                   select p;
            
            foreach (var item in tempSearch)
            {
                tempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City});
            }

            IEnumerable<PeopleViewModel> tempSearch2 = from p in PeopleViewModel.listPeople
                                                        where p.City == _searchSubject
                                                        select p;

            foreach (var item in tempSearch2)
            {
                tempSearchList.Add(new PeopleViewModel { Id = item.Id, Name = item.Name, Phone = item.Phone, City = item.City });
            }

            if (tempSearchList.Count == 0)
            {
                Message = "The name or city does not exist in the list.";
                Message2 = "Do a new search. (Leave empty to show whole list.)";

            }
        }
    }

}
