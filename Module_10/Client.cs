using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    class Client
    {
        public string MiddleName { get; private set; } //Фамилия
        public string FirstName { get; private set; } //Имя
        public string LastName { get; private set; } //Отчество
        public string PhoneNumber { get; private set; } //Номер телефона
        public string Passport { get; private set; } //Паспортные данные

        public Client(string middleName, string firstName, string lastName, string phoneNumber, string passport)
        {
            this.MiddleName = middleName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Passport = passport;
        }


        public void ChangeMiddleNameClient(string newMiddleName)
        {
            MiddleName = newMiddleName;
        }

        public void ChangeFirstNameClient(string newFirstName)
        {
            FirstName = newFirstName;
        }

        public void ChangeLastNameClient(string newLastName)
        {
            LastName = newLastName;
        }

        public void ChangePhoneClient(string newPhone)
        {
            PhoneNumber = newPhone;
        }

        public void ChangePassportClient(string newPassport)
        {
            Passport = newPassport;
        }
    }
}
