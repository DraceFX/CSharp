using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class Log
    {
        public DateTime Time { get; }
        public string Data { get; set; }
        public string AddOrChange { get; set; }
        public string Who { get; set; }

        public Log()
        {
            Time = DateTime.Now;
        }

        public void LogSave()
        {
            using (StreamWriter sr = new StreamWriter("logs.txt", true))
            {
                sr.WriteLine($"{Time} {Who} {Data} {AddOrChange}");
            }
        }
    }
}
