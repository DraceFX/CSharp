using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FullName = "Ф.И.О";
            int Age = 21;
            string Email = "Email";
            float ScoreProg = 4.4f;
            float ScoreMath = 4.9f;
            float ScorePhys = 5f;

            string pathern = "Полное имя:                {0} " +
                                "\nВозраст:                   {1} " +
                                "\nПочта:                     {2} " +
                                "\nБаллы по программированию: {3} " +
                                "\nБаллы по математика:       {4} " +
                                "\nБаллы по физике:           {5} ";

            float SummScore = ScoreMath + ScorePhys + ScoreProg;
            float MiddleScore =(float)Math.Round(SummScore / 3, 1);

            Console.WriteLine(pathern,
                              FullName,
                              Age,
                              Email,
                              ScoreProg,
                              ScoreMath,
                              ScorePhys,
                              SummScore,
                              MiddleScore);

            Console.ReadKey();

            string newpathern = "\n\nСумма балов по предметам:            {0}" +
                                "\nСредний балл по всем предметамм:     {1}\n\n";

            Console.Write(newpathern,
                          SummScore,
                          MiddleScore);
        }
    }
}
