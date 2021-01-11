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
    }

}
