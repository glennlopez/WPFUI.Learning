using System;
using System.Linq;


namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the NumberGuesser Class
            var numberGuesser = new NumberGuesser();

            // Change Maximum Number to 200
            numberGuesser.MaximumNumber = 400;

            // Prompt user
            numberGuesser.InformUser();

            // Attempt to guess users number
            numberGuesser.DiscoverNumber();

            // Readout results
            numberGuesser.AnnounceResults();
        }
    }
}
