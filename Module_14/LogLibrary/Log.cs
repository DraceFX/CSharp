using System.IO;

namespace LogLibrary
{
    public class Log
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
