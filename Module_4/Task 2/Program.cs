using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длинну последовательности: ");
            int a = int.Parse(Console.ReadLine());

            int[] posl = new int[a];
            int min = int.MaxValue;

            Console.WriteLine("Введите последовательность!");
            for (int i = 0; i < a; i++)
            {
                posl[i] = int.Parse(Console.ReadLine());
                if (posl[i]<min) 
                    min = posl[i];
            }

            Console.WriteLine($"наименьшее число: {min}");
            Console.ReadKey();
        }
    }
}
