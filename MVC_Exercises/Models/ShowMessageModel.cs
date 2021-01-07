using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Models
{
    public static class ShowMessageModel
    {
        public static int BodyTemp { get; set; }
        public static string Message { get; set; }

        public static void FeverCheckMethod(int value)
        {
            BodyTemp = value;

            if (BodyTemp < 35)
            {
                Message = "You have Hypothermia!";
            }
            else if (BodyTemp > 40)
            {
                Message = "Dude, You have Hyperthermia!";
            }
            else
            {
                Message = "You're fine!";
            }
        }
    }
}
