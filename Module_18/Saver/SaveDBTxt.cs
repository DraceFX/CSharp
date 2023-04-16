using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    public class SaveDBTxt : ISaveDB
    {
        private string nameOfFile;
        public SaveDBTxt(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }
        public void SaveDB(string NameOfFile, Repository repos)
        {
            File.Create($"{nameOfFile}.txt").Close();
            using (StreamWriter sw = new StreamWriter($"{nameOfFile}.txt"))
            {
                foreach (var item in repos.animalsToList)
                {
                    sw.Write("{0}\t{1}\t{2}\t{3}",
                        item.Type,
                        item.Animal,
                        item.Sex,
                        item.Weight.ToString());
                    sw.Write('\n');
                }
            }
        }
    }
}
