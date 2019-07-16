using System;
using System.Linq;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Think of a number 1 - 100: ");
            Console.ReadLine();

            uint maxNum = 100;
            uint guessCounter = 0;          // Counter for the number of guesses computer took

            uint guessRange_Lower = 0;
            uint guessRange_Upper = maxNum / 2;

            // recursive logic
            while (guessRange_Lower != guessRange_Upper)
            {
                guessCounter++;
                Console.WriteLine("Is your number between {0} and {1} (Y/N)?", guessRange_Lower, guessRange_Upper);
                string response = Console.ReadLine();



                /* Lower lever programming way
                bool response_isNull = (response !=   null && response.Length > 0);
                if (response_isNull && (response[0] == 'y' || response[0] == 'Y') )
                {
                    guessRange_Upper /= 2;
                }
                else
                {
                       
                }
                */



                // C# way - using LINQ and "?" as null checker
                // user: yes - we know its between 0 and 50
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // set the maxNum to lower range number
                    maxNum = guessRange_Lower;
                    guessRange_Upper /= 2; 

                }
                else
                {
                    // user: no - we know its between 51 and 100


                }
                
            }

        }
    }
}
