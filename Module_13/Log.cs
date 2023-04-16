using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Module_12
{
    class Log
    {
        public string Time { get; set; }
        public string FIO { get; set; }
        public string Action { get; set; }

        public Log(string Time, string concreteUser, string action)
        {
            this.Time = Time;
            this.FIO = concreteUser;
            this.Action = action;
        }
        public void LogSave()
        {
            using (StreamWriter sr = new("logs.txt", true))
            {
                sr.WriteLine($"{Time}\t{FIO}\t{Action}");
            }
        }
    }
}
