using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int a = int.Parse(Console.ReadLine());

            if (a % 2 == 0)
                Console.WriteLine("Данное число чётное");

            else
                Console.WriteLine("Данное число нечётное");
            Console.ReadKey();
        }
    }
}
