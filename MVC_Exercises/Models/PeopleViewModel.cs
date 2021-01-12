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
        [DataType(DataType.Text)]
        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public int Phone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Home City")]
        public string City { get; set; }
        
        public static List<PeopleViewModel> listPeople = new List<PeopleViewModel>();
        public List<PeopleViewModel> tempList = new List<PeopleViewModel>();

        public static void CreatePeopleList()
        {
            listPeople.Add(new PeopleViewModel { Id = 1, Name = "Sverre Bumpa Jr", Phone = 087565133, City = "Stockholm" });
            listPeople.Add(new PeopleViewModel { Id = 2, Name = "Alf-Alfa Betasson", Phone = 0760100200, City = "Örebro"});
            listPeople.Add(new PeopleViewModel { Id = 3, Name = "Förste Walter", Phone = 08212325, City = "Reykjavik" });

            NewId = listPeople.Count + 1;
        }
    }

}
