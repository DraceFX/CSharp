using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Module_10
{
    internal class Manager : Consultant, IChangeInfo
    {
        public Manager()
            : base()
        {
        }

        public void AddClient()
        {
            Console.WriteLine("\nВведите фамилию!");
            string middleName = Console.ReadLine();

            Console.WriteLine("\nВведите имя!");
            string firstName = Console.ReadLine();

            Console.WriteLine("\nВведите отчество!");
            string lastName = Console.ReadLine();

            Console.WriteLine("\nВведите номер телефона!");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("\nВведите паспорт!");
            string passport = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("database.txt", true))
            {
                sw.WriteLine($"\n{middleName} {firstName} {lastName} {phoneNumber} {passport}");
            }
        }

        public void ChangeInfo(Client client, Log logs)
        {
            Console.WriteLine("Что хотите изменить?\n" +
                              "\n1 Фамилия" +
                              "\n2 Имя" +
                              "\n3 Отчество" +
                              "\n4 Телефон" +
                              "\n5 Паспорт");
            int selectToChange = int.Parse(Console.ReadLine());
            ChangeLogManag(selectToChange);

            switch (selectToChange)
            {
                case 1:
                    logs.AddOrChange = "фамилию";
                    Console.WriteLine("\nВведите новую фамилию!\n");
                    string newMiddleName = Console.ReadLine();
                    client.ChangeMiddleNameClient(newMiddleName);
                    Console.WriteLine("\nФамилия успешно изменена\n");
                    break;
                case 2:
                    logs.AddOrChange = "имя";
                    Console.WriteLine("\nВведите новое имя!\n");
                    string newFirtsname = Console.ReadLine();
                    client.ChangeFirstNameClient(newFirtsname);
                    Console.WriteLine("\nИмя успешно изменено\n");
                    break;
                case 3:
                    logs.AddOrChange = "отчество";
                    Console.WriteLine("\nВведите новое отчество!\n");
                    string newLastName = Console.ReadLine();
                    client.ChangeLastNameClient(newLastName);
                    Console.WriteLine("\nОтчество успешно изменено\n");
                    break;
                case 4:
                    logs.AddOrChange = "номер телефона";
                    base.ChangePhone(client);
                    break;
                case 5:
                    logs.AddOrChange = "паспортные данные";
                    Console.WriteLine("\nВведите новый паспорт!\n");
                    string newPassport = Console.ReadLine();
                    client.ChangePassportClient(newPassport);
                    Console.WriteLine("\nПаспорт успешно изменён\n");
                    break;
                default:
                    break;
            }

        }
        public void ChangeLogManag(int selectToChange)
        {

        }

    }
    interface IChangeInfo
    {
        void AddClient();
        void ChangeInfo(Client client, Log logs);
        void ChangeLogManag(int selectToChange);
    }
}
