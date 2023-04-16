using System.Runtime.CompilerServices;

namespace Module_15
{
    class Program
    {
        static object o = new();
        static void Print(object text)
        {
            Random r = new();
            int id = Thread.CurrentThread.ManagedThreadId;
            lock (o)
            {
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"{text} => имя потока {id}");
                    Thread.Sleep(r.Next(500, 800));
                }
            }
        }

        static async void Method(object text) => await Task.Run(() => Print(text));

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string str = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Task thr = Task.Factory.StartNew(Method, str);
            }

            Console.ReadLine();
        }
    }
}