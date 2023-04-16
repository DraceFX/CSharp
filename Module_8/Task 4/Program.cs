using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task_4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите ФИО\n");
            string name = Console.ReadLine();

            Console.WriteLine("\nВведите Улицу\n");
            string Street = Console.ReadLine();

            Console.WriteLine("\nВведите номер дома\n");
            string HouseNumber = Console.ReadLine();

            Console.WriteLine("\nВведите номер квартиры\n");
            string FlatNumber = Console.ReadLine();

            Console.WriteLine("\nВведите мобильный телефон\n");
            string MobilePhone = Console.ReadLine();

            Console.WriteLine("\nВведите домашний номер\n");
            string FlatPhone = Console.ReadLine();

            List<Person> people = new List<Person>();
            Address address = new Address(Street, HouseNumber, FlatNumber);
            Phones phones = new Phones(MobilePhone, FlatPhone);

            for (int i = 1; i <= 3; i++)
            {
                people.Add(new Person(name, address, phones));
            }

            SerializePerson(people, "People.xml");
        }

        static void SerializePerson(List<Person> concretePerson, string Path)
        {
            XDocument xDoc = new XDocument();
            XElement elements = new XElement("Persons");

            foreach (var item in concretePerson)
            {
                var element = new XElement("Person", new XAttribute("name", item.Name),
                                new XElement("Address",
                                    new XElement("Street", item.address.Street),
                                    new XElement("HouseNumber", item.address.HouseNumber),
                                    new XElement("FlatNumber", item.address.FlatNumber)),
                                new XElement("Phones",
                                    new XElement("MobilePhone", item.phones.MobilePhone),
                                    new XElement("FlatPhone", item.phones.FlatPhone)));
                elements.Add(element);
            }

            xDoc.Add(elements);
            xDoc.Save(Path);
        }
    }
}
