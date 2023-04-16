using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    public class RepositoryFactory
    {
        public static Repository GetRepositrory() 
        {
            List<IAnimal> temp = new List<IAnimal>();

            using (StreamReader sr = new StreamReader("Animals.txt", true))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] item = line.Split('\t');
                    temp.Add(AnimalFactory.GetAnimal(item[0], item[1], item[2], Convert.ToSingle(item[3])));
                }
            }
            return new Repository(temp);
        }
    }
}
