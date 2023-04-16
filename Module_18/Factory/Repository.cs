using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    public class Repository
    {
        List<IAnimal> anim;
        public Repository() => anim =new List<IAnimal>();
        public Repository(IEnumerable<IAnimal> args) => anim = args.ToList<IAnimal>();
        public void Add(IAnimal animal) => anim.Add(animal);
        public List<IAnimal> animalsToList => anim.ToList();
        public void Delete(IAnimal animal) => anim.Remove(animal);
    }
}
