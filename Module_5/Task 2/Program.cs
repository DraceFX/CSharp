using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static string[] InputPhrase(string predl)
        {
            string[] mass = predl.Split(' ');
            return mass;
        }
        static void ReversWords(string predl)
        {
            string NewString = "";
            for (int i = InputPhrase(predl).Length-1; i >= 0; i--)
            {
                NewString += InputPhrase(predl)[i] + " ";
            }
            Console.WriteLine(NewString);
        }
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string predl = Console.ReadLine();
            ReversWords(predl);
        }
    }
}
