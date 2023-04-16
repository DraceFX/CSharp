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
            Console.WriteLine("Введите максимально число для игры:");
            int a = int.Parse(Console.ReadLine());

            Random random = new Random();

            int b = random.Next(a);
            Console.WriteLine("ИГРА НАЧАЛАСЬ!");
            string ans;

            do
            {
                ans = Console.ReadLine();
                if (string.IsNullOrEmpty(ans))
                {
                    Console.WriteLine("Вы утсали?");
                    break;
                }

                if (int.Parse(ans) < b)
                    Console.WriteLine("Введённое число меньше загаданного");
                else if (int.Parse(ans) > b)
                    Console.WriteLine("Введённое число больше загаданного");

            } while (int.Parse(ans) != b);

            if (string.IsNullOrEmpty(ans)) 
                Console.WriteLine("Загаданное число: " + b);

            else 
                Console.WriteLine("Вы угадали!");
        }
    }
}
