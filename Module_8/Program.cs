using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random random= new Random();

            //Генерация 100 случайных чисел
            for (int i = 0; i <= 100; i++)
                list.Add((int)random.Next(0,100));

            //Вывод 100 случайных чисел
            foreach (var item in list)
                Console.Write(item + " ");

            Console.ReadKey();
            Console.Clear();

            //Удаление чисел в диапазоне от 25 до 50
            foreach (var item in list.ToArray())
            {
                if ((item > 25) && (item < 50))
                    list.Remove(item);
            }

            //Вывод результата
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]} ");

            Console.ReadKey();
        }
    }
}
