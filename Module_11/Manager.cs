using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module_11
{
    internal class Manager : Consultant, IChangeInfo
    {
        public Manager()
            : base()
        {
        }

        public void AddClient(string MiddleName, string FirstName, string LastName, string PhoneNumber, string Passport)
        {
            using (StreamWriter sw = new("database.txt", true))
            {
                sw.WriteLine($"{MiddleName} {FirstName} {LastName} {PhoneNumber} {Passport}");
            }
            LogChange("Менеджер", "добавил", "нового клиента");
        }

        public void ChangeInfo(string MiddleName, string FirstName, string LastName, string PhoneNumber, string Passport, Client client)
        {
            if (client == null)
                return;

            if (client.MiddleName != MiddleName)
            {
                client.ChangeMiddleNameClient(MiddleName);
                LogChange("Менеджер", "изменил", "фамилию");
            }

            if (client.FirstName != FirstName)
            {
                client.ChangeFirstNameClient(FirstName);
                LogChange("Менеджер", "изменил", "имя");
            }

            if (client.LastName != LastName)
            {
                client.ChangeLastNameClient(LastName);
                LogChange("Менеджер", "изменил", "отчество");
            }

            if (client.PhoneNumber != PhoneNumber)
            {
                base.ChangePhone(client, PhoneNumber);
                LogChange("Менеджер", "изменил", "номер телефона");
            }

            if (client.Passport != Passport)
            {
                client.ChangePassportClient(Passport);
                LogChange("Менеджер", "изменил", "паспорт");
            }
        }

        public void LogChange(string Who, string Data, string AddOrChange)
        {
            string Time = DateTime.Now.ToString();
            Log log = new(Time, Who, Data, AddOrChange);

            log.Who = Who;
            log.Data = Data;
            log.AddOrChange = AddOrChange;

            log.LogSave();
        }
    }
}
