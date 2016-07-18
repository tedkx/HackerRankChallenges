using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Dynamic Array
/// https://www.hackerrank.com/challenges/dynamic-array
/// </summary>
class Solution
{
    static Int64 LastAns = 0;
    static int NumOfSequences = 0;
    static int NumOfQueries = 0;

    static void Main(string[] args)
    {
        var data = Console.ReadLine().Split(' ');
        NumOfSequences = Int32.Parse(data[0]);
        NumOfQueries = Int32.Parse(data[1]);

        var seqList = new Sequence[NumOfSequences];
        for (var i = 0; i < NumOfSequences; i++)
            seqList[i] = new Sequence();

        for (var i = 0; i < NumOfQueries; i++)
        {
            var queryData = Console.ReadLine().Split(' ');
            Query(Int32.Parse(queryData[0]), Int64.Parse(queryData[1]), Int64.Parse(queryData[2]), seqList);
        }
    }

    static void Query(int queryType, Int64 x, Int64 y, Sequence[] list)
    {
        var idx = (int)((x ^ LastAns) % NumOfSequences);

        if (queryType == 1)
        {
            list[idx].Add(y);
        }
        else
        {
            Sequence seq = list[idx];
            int yIdx = (int)(y % seq.Count);
            LastAns = seq[yIdx];
            Console.WriteLine("{0}", LastAns);
        }
    }

    class Sequence : List<Int64>
    { }
}
