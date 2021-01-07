using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercises.Models
{
    public class GuessingGameModel
    {
        public static int GuessedNumber { get; set; }
        public static string Message { get; set; }
        public static int RndNumber { get; set; }

        public static Random redRum = new Random();
        //RndNumber = redRum.Next(1, 10);

        public static void GuessingGameMethod(int _guessedNumber)
        {
            int AmountOfTries = 1;
            //Random redRum = new Random();
            RndNumber = redRum.Next(1, 10);
            GuessedNumber= _guessedNumber;
            Message = " ";

            if (GuessedNumber < RndNumber)
            {
                Message = "Eeek, no can do! För lågt!";  
                AmountOfTries++;
            }
            else if (GuessedNumber > RndNumber)
            {
                Message = "Yikes! För högt!";
                AmountOfTries++;
            }
 
            if (GuessedNumber == RndNumber)
            {
                Message = "Snyggt! Det tog dig " + AmountOfTries + " försök att hitta rätt.";
            }

            if (GuessedNumber < 1 || GuessedNumber > 10)
            {
                Message = " Your number is not in the range 1-10";
            }
        }
    }
}
