using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_7
{
    class Programm
    {
        static void Main(string[] args)
        {
            const string data = "database.txt";
            int start = 0;

            Repository repository = new Repository();

            while (true)
            {
                Console.WriteLine("Для ввода новых данных - введите 1" +
                                  "\nДля чтения данных - введите 2" +
                                  "\nДля удаления работника - введите 3" +
                                  "\nДля просмотра одной записи данных - введите 4" +
                                  "\nДля чтения данных в диапозоне дат - введите 5");
                Console.WriteLine();

                int cons = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (cons == 1)
                    start = 1;
                else if (cons == 2)
                    start = 2;
                else if (cons == 3)
                    start = 3;
                else if (cons == 4)
                    start = 4;
                else if (cons == 5)
                    start = 5;

                if (File.Exists(data))
                {
                    switch (start)
                    {
                        case 1:
                            Console.Clear();

                            repository.AddWorker(new Worker());

                            Console.ReadKey();
                            Main(args);
                            break;

                        case 2:
                            Console.Clear();

                            Writer(repository);

                            Console.ReadKey();
                            Main(args);
                            break;

                            case 3:
                            Console.Clear();

                            Console.WriteLine("Введите Id работника для удаленние его данных");
                            repository.DeleteWorker(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Работник удалён\n");

                            Console.WriteLine(repository.GetAllWorkers());
                            Console.WriteLine();

                            Console.ReadKey();
                            Main(args);
                            break;

                            case 4:
                            Console.Clear();

                            Console.WriteLine("Введите Id работника для просмотра его данных\n");
                            repository.GetWorkerById(int.Parse(Console.ReadLine()));

                            Console.WriteLine();
                            Console.ReadKey();
                            Main(args);
                            break;

                            case 5:
                            Console.Clear();

                            Console.WriteLine("Введите диапозон дат в формате yyyy.mm.dd\n");

                            Console.WriteLine("Введите первую дату\n");
                            var dateFrom = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine();

                            Console.WriteLine("Введите вторую дату\n");
                            var dateTo = DateTime.Parse(Console.ReadLine());

                            repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);

                            Console.WriteLine();
                            Console.ReadKey();
                            Main(args);
                            break;

                        default:
                            break;
                    }
                }

                else
                {
                    File.WriteAllText(data, "");
                    Console.WriteLine("Данного файла не существует. Файл создан! Заполните его!\n");
                }

                if (cons != 1 || cons != 2 || cons !=3 || cons!=4 || cons!=5)
                    break;

                Console.WriteLine();
            }
        }

        static void Writer(Repository repository)
        {
            foreach (var item in repository.GetAllWorkers())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5:d} Город:{6}",
                                    item.Id,
                                    item.AddDate,
                                    item.FullName,
                                    item.Age,
                                    item.Height,
                                    item.BirthDate,
                                    item.BirthPlace);
            }

            Console.WriteLine();
        }
    }
    public struct Worker
    {
        public int Id { get; set; }

        public string AddDate { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }
    }
}
