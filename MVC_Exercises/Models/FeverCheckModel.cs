using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Models
{
    public class FeverCheckModel
    {
        public int BodyTemp { get; set; }

        public void FeverCheckMethod(int value)
        {
            BodyTemp = value;
        }
    }
}
