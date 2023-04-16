using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк для матрицы: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов для матрицы: ");
            int b = int.Parse(Console.ReadLine());

            int[,] matrix = new int[a, b];

            Random rand = new Random();
            int sum = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i, j] = rand.Next(100);
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма массива: {sum}");
            Console.ReadKey();
        }
    }
}
