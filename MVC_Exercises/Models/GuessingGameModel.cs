using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public static bool Win { get; set; }
        public static List<int> ShowGuesses { get; set; }

        public static List<int> Guesses { get; set; } = new List<int>();

        //public static List<int> Guesses = new List<int>();
        
        
        //***Spara list items i Session values

        public static int AmountOfTries = 1;

        public static void GuessingGameMethod()
        {
            Guesses.Add(GuessedNumber);
            Message = " ";

            if (GuessedNumber < 1 || GuessedNumber > 100)
            {
                Message = "Your number is not in the range 1-100";
                //AmountOfTries++;
            }
            else if (GuessedNumber < RndNumber)
            {
                Message = "Eeek, no can do! För lågt!";  
                AmountOfTries++;                
            }
            else if (GuessedNumber > RndNumber)
            {
                Message = "Yikes! För högt!";
                AmountOfTries++;
            } 
            else //if (GuessedNumber == RndNumber)
            {
                Message = "Snyggt! Det tog dig " + AmountOfTries + " försök att hitta rätt.";
                // funktion med knapp för att ladda om sidan
                AmountOfTries = 1;
                Win = true;
            }            
        }

        public static int RndNumb()
        {            
            Random redRum = new Random();
            RndNumber = redRum.Next(1, 100);
            
            return RndNumber;
        }
    }
}
