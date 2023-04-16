using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_11
{
    interface IChangeInfo
    {
        void AddClient(string MiddleName, string FirstName, string LastName, string PhoneNumber, string Passport);
        void ChangeInfo(string MiddleName, string FirstName, string LastName, string PhoneNumber, string Passport, Client client);
    }

    interface IChangePhone
    {
        void ChangePhone(Client client, string PhoneNumber);
        void ChangeLog();
    }
}
