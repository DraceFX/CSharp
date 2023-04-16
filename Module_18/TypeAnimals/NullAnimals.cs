using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    internal class NullAnimals: IAnimal
    {
        public string Type { get; set; } //тип животного
        public string Animal { get; set; } //вид животного
        public string Sex { get; set; } //пол животного
        public float Weight { get; set; } //вес животного

        public NullAnimals(string type, string animal, string sex, float weight)
        {
            this.Type = type;
            this.Animal = animal;
            this.Sex = sex;
            this.Weight = weight;
        }
    }
}
