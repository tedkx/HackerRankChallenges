using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HackerRankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var challengeName = ConfigurationManager.AppSettings["Challenge"];
            Type t = System.Reflection.Assembly.Load("HackerRankChallenges").GetType("HackerRankChallenges." + challengeName);
            Activator.CreateInstance(t);

            Console.Write("Press any key to exit");
            Console.ReadLine();
        }
    }
}
