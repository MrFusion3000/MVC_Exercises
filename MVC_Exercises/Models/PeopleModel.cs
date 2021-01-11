using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Models
{
    public class PeopleModel
    {
        [Required]        
        public int Id { get; set; }

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


        public static List<PeopleModel> PeopleList()
        {
            List<PeopleModel> listPeople = new List<PeopleModel>();
            PeopleModel people = new PeopleModel();

            people.Id = 1;
            people.Name = "Sverre Bumpa Jr";
            people.Phone = 087565133;
            people.City = "Stockholm";
            listPeople.Add(people);

            people = new PeopleModel();
            people.Id = 2;
            people.Name = "Alf-Alfa Betasson";
            people.Phone = 0760100200;
            people.City = "Örebro";
            listPeople.Add(people);

            people = new PeopleModel();
            people.Name = "Förste Walter";
            people.Phone = 08212325;
            people.City = "Reykjavik";
            listPeople.Add(people);

            return listPeople;
        }
    }

}
