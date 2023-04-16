using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module_6
{
    internal class Program
    {
        const string data = "database.txt";
        static void Main(string[] args)
        {
            int start = 0;
            while (true)
            {
                Console.WriteLine("Для ввода новых данных введите 1\nДля чтения данных введите 2\nДля выхода из программы введите 3");

                int cons = int.Parse(Console.ReadLine());

                if (cons == 1)
                    start = 1;
                else if (cons == 2)
                    start = 2;

                if (File.Exists(data))
                {
                    switch (start)
                    {
                        case 1:
                            EnterStroke();
                            break;

                        case 2:
                            ReadStroke();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    File.WriteAllText(data, "");
                    Console.WriteLine("Данного файла не существует. Файл создан! Заполните его!\n");
                    EnterStroke();
                }
                if (cons != 1 || cons != 2)
                    break;
                Console.WriteLine();
            }
            
        }
        static void EnterStroke()
        {
            int count = 1;
            string line;

            using (TextReader reader = new StreamReader(data))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                }
            }
            
            using (StreamWriter write = new StreamWriter(data, true))
            {
                char key;
                do
                {
                    string note = string.Empty;

                    int id = count;
                    Console.WriteLine($"ID: {id}\t");
                    note += $"{id}\t ";
                    count++;

                    string data = DateTime.Now.ToString().Remove(16, 3);
                    Console.WriteLine($"Дата добавления: {data} ");
                    note += $"{data}\t ";

                    Console.Write("Введите Ф.И.О работника: ");
                    note += $"{Console.ReadLine()}\t ";

                    Console.Write("Введите возраст работника: ");
                    int age = int.Parse(Console.ReadLine());
                    note += $"{age}\t ";

                    Console.Write("Введите рост работника: "); 
                    int height = int.Parse(Console.ReadLine());
                    note += $"{height}\t ";

                    Console.Write("Введите дату рождения работника: ");
                    note += $"{Console.ReadLine()}\t ";                 //Каждый может вводить даты по своему например: 20 июля 2020; 20.12.2019; 10/02/2022, поэтому оставляю string 

                    Console.Write("Введите место рождения работника: ");
                    note += $"{Console.ReadLine()}\t <";

                    write.WriteLine(note);
                    Console.WriteLine("\nДля продолжения нажмите 1\nДля выхода нажмите 2");

                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == '1');
            }
            Console.WriteLine();
        }

        static void ReadStroke()
        {
            using (StreamReader dt = new StreamReader(data, true))
            {
                string read;

                    while ((read = dt.ReadLine()) != null)
                    {
                        string[] DataBase = read.Split('<');
                        foreach (var item in DataBase)
                        {
                            Console.WriteLine(item);
                        }
                    }
            }
            Console.WriteLine();

        }
    }
}
