using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5
{
    internal class Program
    {
        static string[] Sent(string predl)
        {
            string[] mass = predl.Split(' ','.',',','!','?');
            return mass;
        }
        static void Result(string predl)
        {
            foreach (var pred in Sent(predl))
            {
                Console.WriteLine($"{pred}");
            }
        }

        //Функция Sent в методе Result

        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string predl = Console.ReadLine();
            Result(predl);
        }
    }
}
