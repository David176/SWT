using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD;


namespace TDDApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = "";


            while (answer != "yes" || answer != "Yes")
            {
                Console.WriteLine("What is your name?");
                var name = Console.ReadLine();
                Console.WriteLine("Your name is: " + name + ". Correct?");
                answer = Console.ReadLine();
                if (answer == "yes" || answer == "Yes")
                {
                    Console.WriteLine("Good for you, that is a great name " + name);
                    break;
                }
                else
                {
                    Console.WriteLine("Could not read your name, sorry");
                }
            }

            var hej = new Cartesian2DVector();
            hej.coordinateX = 1;
            hej.coordinateX = 2;

            var hej2 = new VectorCalculator();

            hej2.AddTwoVectors(hej,hej);
        }
    }
}
