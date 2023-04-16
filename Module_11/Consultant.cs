using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Module_11
{
    internal class Consultant : IChangePhone
    {
        public Consultant()
        {
        }

        public void ChangePhone(Client client, string PhoneNumber)
        {
            client.ChangePhoneClient(PhoneNumber);
        }

        public void ChangeLog()
        {
            string Time = DateTime.Now.ToString();
            string Who = "Консультант";
            string Data = "изменил";
            string AddOrChange = "номер телефона";

            Log log = new(Time, Who, Data, AddOrChange);
            log.LogSave();
        }
    }
}
