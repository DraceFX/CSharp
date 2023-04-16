using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_4
{
    public class Person
    {
        public Address address { get; set; } = new Address();
        public Phones phones { get; set; } = new Phones();

        public Person()
        {
        }

        public Person(string Name, Address address, Phones phones)
        {
            this.name = Name;
            this.address = address;
            this.phones = phones;
        }

        #region Свойства
        public string Name { get { return this.name; } set { this.name = value; } }                          //Имя
        #endregion

        #region Поля
        private string name;            //ФИО
        #endregion
    }

    public class Address
    {
        public Address()
        {
        }

        public Address(string Street, string HouseNumber, string FlatNumber)
        {
            this.street = Street;
            this.houseNumber = HouseNumber;
            this.flatNumber = FlatNumber;
        }

        #region Свойства
        public string Street { get { return this.street; } set { this.street = value; } }                   //Улица
        public string HouseNumber { get { return this.houseNumber; } set { this.houseNumber = value; } }    //Номер дома
        public string FlatNumber { get { return this.flatNumber; } set { this.flatNumber = value; } }       //Номер квартиры
        #endregion

        #region Поля
        private string street;          //Улица
        private string houseNumber;     //Номер дома
        private string flatNumber;      //Номер Квартиры
        #endregion
    }

    public class Phones
    {
        public Phones()
        {
        }

        public Phones(string MobilePhone, string FlatPhone)
        {
            this.mobilePhone = MobilePhone;
            this.flatPhone = FlatPhone;
        }

        #region Свойства
        public string MobilePhone { get { return this.mobilePhone; } set { this.mobilePhone = value; } }    //Мобильный телефон
        public string FlatPhone { get { return this.flatPhone; } set { this.flatPhone = value; } }         //Домашний телефон
        #endregion

        #region Поля
        private string mobilePhone;     //Мобильный телефон
        private string flatPhone;       //Домашний телефон
        #endregion
    }
}
