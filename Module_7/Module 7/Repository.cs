using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;

namespace Module_7
{
    class Repository
    {
        const string data = "database.txt"; 

        public Worker[] GetAllWorkers()
        {
            int count = Counter(data);

            Worker[] workers = new Worker[count];

            using (StreamReader dt = new StreamReader(data, true))
            {
                string read;
                int i = 0;
               
                while ((read = dt.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(read))
                        continue;

                    string[] item = read.Split('\t');

                    workers[i].Id = int.Parse(item[0]);
                    workers[i].AddDate = item[1];
                    workers[i].FullName = item[2];
                    workers[i].Age = int.Parse(item[3]);
                    workers[i].Height = int.Parse(item[4]);
                    workers[i].BirthDate = DateTime.Parse(item[5]);
                    workers[i].BirthPlace = item[6];
                    i++;
                }
            }
            return workers;
        }
         
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = GetAllWorkers();

            for (int i = 0; i < workers.Length; i++)
            {
                if (id == workers[i].Id)
                {
                    Console.WriteLine($"\n{workers[i].Id}\t" +
                                $"{workers[i].AddDate}\t" +
                                $"{workers[i].FullName}\t" +
                                $"{workers[i].Age}\t" +
                                $"{workers[i].Height}\t" +
                                $"{workers[i].BirthDate:d}\t" +
                                $"{workers[i].BirthPlace}");
                }

            }
            return workers[id];
        }

        public void DeleteWorker(int id)
        {
            Worker[] workers = GetAllWorkers();

            File.WriteAllText(data, "");

            using (StreamWriter delID = new StreamWriter(data))
            {
                for (int i = 0; i < workers.Length - 1; i++)
                {
                    if (id >= workers[i].Id)
                    {
                        workers[i] = workers[i + 1];
                        workers[i].Id = workers[i].Id - 1;
                    }

                    delID.WriteLine($"{workers[i].Id}\t" +
                                    $"{workers[i].AddDate}\t" +
                                    $"{workers[i].FullName}\t" +
                                    $"{workers[i].Age}\t" +
                                    $"{workers[i].Height}\t" +
                                    $"{workers[i].BirthDate:d}\t" +
                                    $"{workers[i].BirthPlace}");
                }
            }
        }

        public void AddWorker(Worker worker)
        {
            int count = Counter(data);

            using (StreamWriter write = new StreamWriter(data, true))
            {
                char key;
                do
                {
                    string note = string.Empty;

                    int id = count + 1;
                    Console.WriteLine($"ID: {id}\t");
                    note += $"\n{id}\t";
                    count++;

                    worker.AddDate = DateTime.Now.ToString().Remove(DateTime.Now.ToString().Length - 3,3);
                    Console.WriteLine($"Дата добавления: {worker.AddDate}");
                    note += worker.AddDate + "\t";

                    Console.Write("Введите Ф.И.О работника: ");
                    note += worker.FullName =Console.ReadLine() + "\t";

                    Console.Write("Введите возраст работника: ");
                    worker.Age = int.Parse(Console.ReadLine());
                    note += worker.Age + "\t";

                    Console.Write("Введите рост работника: ");
                    worker.Height = int.Parse(Console.ReadLine());
                    note += worker.Height + "\t";

                    Console.Write("Введите дату рождения работника (формат yyyy.mm.dd): ");
                    worker.BirthDate = DateTime.Parse(Console.ReadLine());
                    note += worker.BirthDate.ToShortDateString() + "\t";

                    Console.Write("Введите место рождения работника: ");
                    note += worker.BirthPlace= $"{Console.ReadLine()}";

                    write.Write(note);
                    Console.WriteLine("\nДля продолжения нажмите 1\nДля выхода нажмите 2");

                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == '1');
            }
            Console.WriteLine();
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers();

            if (dateFrom > dateTo)
                (dateFrom, dateTo) = (dateTo, dateFrom);

            for (int i = 0; i < workers.Length; i++)
            {
                if((workers[i].BirthDate >= dateFrom) && (workers[i].BirthDate <= dateTo))
                {
                    Console.WriteLine($"\n{workers[i].Id}\t" +
                                $"{workers[i].AddDate}\t" +
                                $"{workers[i].FullName}\t" +
                                $"{workers[i].Age}\t" +
                                $"{workers[i].Height}\t" +
                                $"{workers[i].BirthDate:d}\t" +
                                $"{workers[i].BirthPlace}");
                }
            }
            return workers;
        }

        public int Counter(string file)
        {
            int count = 0;
            using (TextReader reader = new StreamReader(file))
            { 
                string line;
                while ((line = reader.ReadLine()) != null)
                    count++;
            }
            return count;
        }
    }
}
