using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Data;

namespace Module_10
{
    internal class Program
    {
        const string data = "database.txt";

        static void Main(string[] args)
        {
            IChangePhone consultant = new Consultant();
            IChangeInfo manager = new Manager();
            List<Client> clients = new List<Client>();
            Log logs = new Log();
            Load(clients);

            Console.WriteLine("Войти в систему как...\n " +
                          "\n1 - Консультант" +
                          "\n2 - Менеджер\n");

            int choose = int.Parse(Console.ReadLine());
            if (File.Exists(data))
            {
                switch (choose)
                {
                    case 1:
                        logs.Who = "Консультант";
                        int index = 1;
                        foreach (var item in clients)
                        {
                            Console.WriteLine(index + " Фамилия: {0} Имя: {1} Отчество: {2} Телефон: {3} Паспорт: {4}",
                                item.MiddleName,
                                item.FirstName,
                                item.LastName,
                                item.PhoneNumber,
                                item.Passport.Replace(item.Passport, "***"));
                            index++;
                        }

                        Console.WriteLine("\nВведите номер клиента");
                        int numClientForConsul= int.Parse(Console.ReadLine());

                        consultant.ChangePhone(clients[numClientForConsul-1]);
                        consultant.ChangeLog(logs);
                        Console.ReadKey();

                        Save(clients);
                        break;

                    case 2:
                        logs.Who = "Менеджер";
                        Console.WriteLine($"\nДля добавления клиента в список - введите 1" +
                                          $"\nДля изменение данных клиента - введите 2");
                        int AddOrChange = int.Parse(Console.ReadLine());

                        if (AddOrChange == 1)
                        {
                            logs.Data = "добавил";
                            logs.AddOrChange = "нового клиента";
                            manager.AddClient();
                        }
                        else if (AddOrChange == 2)
                        {
                            logs.Data = "изменил";
                            index = 1;
                            foreach (var item in clients)
                            {
                                Console.WriteLine(index + " Фамилия: {0} Имя: {1} Отчество: {2} Телефон: {3} Паспорт: {4}",
                                    item.MiddleName,
                                    item.FirstName,
                                    item.LastName,
                                    item.PhoneNumber,
                                    item.Passport);
                                index++;
                            }

                            Console.WriteLine("\nВведите номер клиента\n");
                            int chooseClient = int.Parse(Console.ReadLine());

                            manager.ChangeInfo(clients[chooseClient - 1], logs);
                            Console.ReadKey();
                            Save(clients);
                        }
                        break;

                    default:
                        Console.WriteLine("\nДанного номера не существует! Попробуй снова!\n");
                        choose = int.Parse(Console.ReadLine());
                        break;
                }
            }

            else
            {
                File.WriteAllText(data, "");
                Console.WriteLine("Файл создан, но он пуст! Заполните его!");
            }
            logs.LogSave();
        }

        public static void Load(List<Client> client)
        {
            using (StreamReader sr = new StreamReader(data, true))
            {
                string line;
                int i = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] item = line.Split(' ');
                    client.Add(new Client(item[0], item[1], item[2], item[3], item[4]));
                    i++;
                }
            }
        }

        public static void Save(List<Client> clients)
        {
            File.Create(data).Close();
            using (StreamWriter sr = new StreamWriter(data))
            {
                foreach (var item in clients)
                {
                    sr.WriteLine("{0} {1} {2} {3} {4}",
                        item.MiddleName,
                        item.FirstName,
                        item.LastName,
                        item.PhoneNumber,
                        item.Passport);
                }
            }
        }
    }
}
