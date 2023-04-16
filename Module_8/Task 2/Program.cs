using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> PhoneBook = new Dictionary<int, string>();
            //      Номер тел,   ФИО

            int number; // Номера Тел

            string FIO; // ФИО

            for (int i = 0; i <= PhoneBook.Count; i++)
            {
                Console.WriteLine("Введите номер телефона\n");
                number = int.Parse(Console.ReadLine());

                Console.WriteLine("\nВведите ФИО\n");
                FIO = Console.ReadLine();

                PhoneBook.Add(number, FIO);

                Console.WriteLine("\nДля продолжения добавления данных - введите любой символ\n" +
                                    "Для завершениея добавлен данных - нажмите Enter\n");

                string any = Console.ReadLine();

                if (any != string.Empty)
                    i = 0;

                else if (any == string.Empty)
                    break;
            }

            Console.WriteLine("Введите номер телефона владельца\n");
            number = int.Parse(Console.ReadLine());

            if (PhoneBook.TryGetValue(number, out FIO))
                Console.WriteLine(FIO);

            else
                Console.WriteLine("Данного номера не существует\n");

            Console.ReadKey();
        }
    }
}
