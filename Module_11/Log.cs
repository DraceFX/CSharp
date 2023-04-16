using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_11
{
    internal class Log
    {
        public string Time { get; set; }
        public string Who { get; set; }
        public string Data { get; set; }
        public string AddOrChange { get; set; }

        public Log(string Time, string Who, string Data, string AddOrChange)
        {
            this.Time = Time;
            this.Who = Who;
            this.Data = Data;
            this.AddOrChange = AddOrChange;
        }

        public void LogSave()
        {
            using (StreamWriter sr = new("logs.txt", true))
            {
                sr.WriteLine($"{Time}\t{Who}\t{Data}\t{AddOrChange}");
            }
        }
    }
}
