using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18
{
    internal class SaveInPdf : ISaveDB
    {
        private string nameOfFile;
        public SaveInPdf(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }
        public void SaveDB(string NameOfFile, Repository repos)
        {
            File.Create($"{nameOfFile}.pdf").Close();
            using (StreamWriter sw = new StreamWriter($"{nameOfFile}.pdf"))
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
