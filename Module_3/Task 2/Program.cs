using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру BLACKJACK!");

            Console.WriteLine("Сколько у Вас карт на руках?");
            int a = int.Parse(Console.ReadLine());

            int c = 0;

            for (int i = 0 ; i < a; i++)
            {
                Console.Write("Введите номинал краты: ");

                string b = Console.ReadLine();
                switch (b)
                {
                    case "T":
                        if (c + 11 > 21)
                            c++;
                        else
                            c += 11;
                        break;
                    case "2":
                        c += 2;
                        break;
                    case "3":
                        c += 3;
                        break;
                    case "4":
                        c += 4;
                        break;
                    case "5":
                        c += 5;
                        break;
                    case "6":
                        c += 6;
                        break;
                    case "7":
                        c += 7;
                        break;
                    case "8":
                        c += 8;
                        break;
                    case "9":
                        c += 9;

                        break;
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                        c += 10;
                        break;

                    default:
                        break;
                }
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }
    }
}
