using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    class Presenter
    {
        Model model;
        public void SaveAnimals() => model.SaveAnimals();
        public void SaveDataBase() => model.SaveDataBase();

    }
}
