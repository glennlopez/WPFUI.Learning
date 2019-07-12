using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program_A
    {
        // 3. Accessibility levels
        /* Private Variables:
         *      Has Access Restriction
         *      if a variable in class does not have "private" or "public"
         *      pre-fixed to it, then it is "private" by default
         */
        int myPrivateInt1;
        private int myPrivateInt2;


        /* Protected Variables:
         *      Has access restriction to classes that 
         *      do not inherit from Program_A (parent program)
         */
        protected int myProtectedInt1;


        /* Public Variables:
         *      No Access Restriction.
         *      Outside Program, Inside Program, inherited class
         *      all have access to the variable.
         */
        public int myPublicInt1;


        // 4. Diffrent ways to declare variables (members vs properties)
        private string myString1;       // Member - variable that is "private" access
        public string MyPublicString { get; set; }  // Property - variable accessable outside of a class


        public void TestProg()
        {
            MyPublicString = "Modified in TestProg()";
        }

        static void Main(string[] args)
        {
            var myProg = new Program_A();

            // Program_A private variable is accessable
            myProg.myPrivateInt1 = 10;
            myProg.myPrivateInt2 = 11;
            
            // Program_A protected variable is accessable
            myProg.myProtectedInt1 = 12;

            // Program_A public int variable is accessable
            myProg.myPublicInt1 = 14;

            // 5. reading text from user input
            Console.Write("Type a number between 1 and 10: ");
            myProg.MyPublicString = Console.ReadLine();


            // 6. Parsing
            int userNumber;
            if (int.TryParse(myProg.MyPublicString, out userNumber) && userNumber <= 10)
            {

            }
            else
            {
                if (userNumber >= 10)
                {
                    Console.WriteLine("Number larger than 10.");
                }
                else
                {
                    Console.WriteLine("Not a number!");
                }
            }

            Console.WriteLine("User wrote: " + myProg.MyPublicString);
            Console.ReadLine();

        }
    }




    // class Program_B inherits stuff from Program_A
    class Program_B : Program_A
    {
        public Program_B()
        {
            var newProg = new Program_A();

            // Program_A protected variable is accessable from Program_B through inheritance
            myProtectedInt1 = 10;

            // Program_A public variable is accessable from Program_B
            newProg.myPublicInt1 = 12;

        }
    }
}
