using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class Consultant: IChangePhone
    {
        public Consultant()
        {
        }

        public void ChangePhone(Client client)
        {
            Console.WriteLine("\nВведите новый номер телефона\n");
            string newPhone = Console.ReadLine();
            client.ChangePhoneClient(newPhone);
            Console.WriteLine("\nНомер телефона успешно изменён\n");
        }
        public void ChangeLog(Log logs)
        {
            logs.Data = "изменил";
            logs.AddOrChange = "номер телефона";
        }
    }

    interface IChangePhone
    {
        void ChangePhone(Client client);
        void ChangeLog(Log logs);
    }
}
