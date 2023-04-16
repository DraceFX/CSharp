using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    public class AnimalFactory
    {
        public static IAnimal GetAnimal(string Type,
                                        string Animal,
                                        string Sex,
                                        float Weight)
        {
            switch (Type)
            {
                case "Млекопитающий": return new Mammals(Type, Animal, Sex, Weight);
                case "Птица": return new Birds(Type, Animal, Sex, Weight);
                case "Земноводный": return new Amphibians(Type, Animal, Sex, Weight);
                default: return new NullAnimals(Type, Animal, Sex, Weight);
            }
        }
    }
}
