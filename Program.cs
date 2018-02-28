using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingADie
{
    class Program
    {
        static void Main(string[] args)
        {
            Die die = new Die();

            die.TwoSixEventHandler += TwoSixCountPrint;

            die.SumIsGreatEventHandler += SumIsGreaterOf20Print;

            die.Rolling(50);

            Console.Read();

        }

        static void TwoSixCountPrint(int count)
        {
            Console.WriteLine("Two sixes in a row");
            Console.WriteLine("Count: "+count);
        }

        static void SumIsGreaterOf20Print(int[] arr)
        {
            Console.WriteLine("In the consequent 5 tosses the sum of all numbers is greater than or equal to 20.");
            Console.WriteLine("The last 5 tosses");

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }
    }
}
