using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /// <summary>
    /// Number guesser exportable comment example
    /// </summary>
    public class NumberGuesser
    {
        #region Public Properties (variables adapted from Lesson 3)
        /// <summary>
        /// Largest number comp. asks to guess between GuessRange_Lower and this number
        /// </summary>
        public uint MaximumNumber { set; get; } = 100;

        /// <summary>
        /// Counter that keeps track of the ammount of guesses computer took
        /// </summary>
        public uint GuessCounter { private set; get; }

        /// <summary>
        /// Current known minimum number user is thinking of
        /// </summary>
        public uint GuessRange_Lower { private set; get; }

        /// <summary>
        /// Current known maximum number user is thinking of
        /// </summary>
        public uint GuessRange_Upper { private set; get; }
        #endregion

        #region .ctor (Default constructor)
        /// <summary>
        /// Default Class Constructor
        /// </summary>
        public NumberGuesser()
        {

        }
        #endregion

        #region Functions / Methods
        /// <summary>
        /// Prompts the user to think of a number between x and y
        /// </summary>
        public void InformUser()
        {
            Console.WriteLine($"Think of a number 1 - { this.MaximumNumber }.");
            Console.WriteLine("Press [Enter] when ready.");
            Console.ReadLine();
        }

        /// <summary>
        /// Recursive Binary Search Logic for Guessing the user's number
        /// </summary>
        public void DiscoverNumber()
        {
            // reset guess counter at start
            this.GuessCounter = 0;

            // reset guess range on start
            this.GuessRange_Upper = MaximumNumber / 2;

            while (this.GuessRange_Lower != this.GuessRange_Upper)
            {
                this.GuessCounter++;
                Console.WriteLine("Is your number between {0} and {1} (Y/N)?", this.GuessRange_Lower, this.GuessRange_Upper);
                string response = Console.ReadLine();

                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    this.MaximumNumber = this.GuessRange_Upper;
                    this.GuessRange_Upper = this.GuessRange_Upper - ((this.GuessRange_Upper - this.GuessRange_Lower) / 2);
                }
                else
                {
                    this.GuessRange_Lower = this.GuessRange_Upper + 1;
                    uint rangeDiff = this.MaximumNumber - this.GuessRange_Upper;
                    this.GuessRange_Upper += (uint)Math.Ceiling(rangeDiff / 2f);
                }

                // logic for two choices left
                if ((this.MaximumNumber - this.GuessRange_Lower) == 1)
                {
                    this.GuessCounter++;
                    Console.WriteLine("Is your number {0}?", this.GuessRange_Lower);
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ok, your number must be {0} then.", this.MaximumNumber);
                        this.GuessRange_Lower = this.MaximumNumber;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Readback the result to user
        /// </summary>
        public void AnnounceResults()
        {
            Console.WriteLine("Computer took {0} attempts to guess that your number is {1}", this.GuessCounter, this.GuessRange_Lower);
            Console.ReadLine();
        }

        #endregion
    }
}
