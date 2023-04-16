using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool easy = true;
            int b = 2;

            Console.WriteLine("Введите целое число: ");
            int a = int.Parse(Console.ReadLine());

            while(b < a)
            {
                if(a % b == 0)
                {
                    easy = false;
                }
                b++;
            }

            if (easy)
                Console.WriteLine("Число является простым");
            else
                Console.WriteLine("Число не является простым");

            Console.ReadLine();
        }
    }
}
