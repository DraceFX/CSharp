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
            HashSet<int> CheckRep = new HashSet<int>();

            for (int i = 0; i <= CheckRep.Count; i++)
            {
                Console.WriteLine("Введите число\n");
                int num = int.Parse(Console.ReadLine());

                if (CheckRep.Contains(num))                                 //Проверка на повторение
                {
                    Console.WriteLine("\nЧисло уже вводилось ранее!\n"+
                                       "Введите другое число!\n");
                    i--;
                }

                else
                {
                    Console.WriteLine("\nЧисло успешно добавленно!\n");
                    CheckRep.Add(num);
                }
            }

        }
    }
}
