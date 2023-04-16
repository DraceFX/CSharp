using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Module_18
{
    public class DBWriter
    {
        public ISaveDB Mode { get; set; }
        public string Pages { get; set; }
        public DBWriter(ISaveDB Method) => this.Mode = Method;
        private void AnyPages() 
        {
            this.Pages = "";
        }
        public void Save(Repository repos)
        {
            this.AnyPages();
            Mode.SaveDB(Pages, repos);
        }
    }
}
