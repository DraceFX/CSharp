using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    class Model
    {
        static string animalSave = "Animals";
        Repository animals;
        public void SaveAnimals()
        {
            var saveToDocx = new SaveInDocx(animalSave);
            var saveToPdf = new SaveInPdf(animalSave);

            DBWriter dbw = new DBWriter(saveToDocx);
            dbw.Save(animals);

            dbw.Mode = saveToPdf;
            dbw.Save(animals);
        }
        /// <summary>
        /// Сохранение базы данных txt
        /// </summary>
        public void SaveDataBase()
        {
            var saveDbTxt = new SaveDBTxt(animalSave);
            DBWriter dbw = new DBWriter(saveDbTxt);
            dbw.Save(animals);
        }
    }
}
