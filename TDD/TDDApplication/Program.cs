using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("Your name is: " + name + ". Correct?");
            var answer = Console.ReadLine();
            if (answer == "yes" || answer == "Yes")
            {
                Console.WriteLine("Good for you, that is a great name " + name);
            }
            else
            {
                Console.WriteLine("Could not read your name, sorry");
            }
        }
    }
}
