using System;
using System.Linq;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Think of a number 1 - 100.");
            Console.WriteLine("Press [Enter] when ready.");
            Console.ReadLine();

            uint maxNum = 100;
            uint minNum = 51;
            uint guessCounter = 0;          // Counter for the number of guesses computer took

            uint guessRange_Lower = 0;
            uint guessRange_Upper = maxNum / 2;

            // recursive logic
            while (guessRange_Lower != guessRange_Upper)
            {
                guessCounter++;
                Console.WriteLine("Is your number between {0} and {1} (Y/N)?", guessRange_Lower, guessRange_Upper);
                string response = Console.ReadLine();

                // C# way - using LINQ and "?" as null checker
                // user: YES - we know its between 0 and 50
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // set the maxNum to lower range number
                    maxNum = guessRange_Upper;

                    // set new range value to middle of upper and lower range
                    guessRange_Upper = guessRange_Upper - ((guessRange_Upper - guessRange_Lower) / 2);

                }
                // user: NO - we know its between 51 and 100
                else
                {
                    guessRange_Lower = guessRange_Upper + 1;

                    uint rangeDiff = maxNum - guessRange_Upper;

                    guessRange_Upper += (uint)Math.Ceiling(rangeDiff / 2f);

                }

                // if lower guess range is 1 number from upper guess range then there is only two numbers left
                if ( (maxNum - guessRange_Lower) == 1)
                {
                    guessCounter++;
                    Console.WriteLine("Is your number {0}?", guessRange_Lower);
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ok, your number must be {0} then.", maxNum);
                        guessRange_Lower = maxNum;
                        break;
                    }
                }
            }

            Console.WriteLine("Computer took {0} attempts to guess that your number is {1}", guessCounter, guessRange_Lower);
            Console.ReadLine();
        }
    }
}
