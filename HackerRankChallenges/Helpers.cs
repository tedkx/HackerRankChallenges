using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChallenges
{
    public class Helpers
    {
        public static TimeSpan TimeScript(DateTime startTime)
        {
            return DateTime.Now - startTime;
        }
        
        public static void TimeScript(DateTime startTime, string message)
        {
            TimeSpan span = TimeScript(startTime);
            //Console.WriteLine(message + " time: " + span.Minutes + ":" + span.Seconds + "." + span.Milliseconds);
            Console.WriteLine(message + " time: " + span.TotalMilliseconds);
        }
    }
}
