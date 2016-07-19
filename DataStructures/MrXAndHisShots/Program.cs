using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/// <summary>
/// Mr. X and His Shots
/// https://www.hackerrank.com/challenges/x-and-his-shots
/// </summary>
class Solution
{
    static int NumOfShots = 0;
    static int NumOfPlayers = 0;

    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine().Split(' ');
        NumOfShots = int.Parse(firstLine[0]);
        NumOfPlayers = int.Parse(firstLine[1]);

        Range[] ranges = new Range[NumOfShots + NumOfPlayers];

        for(int i = 0; i < NumOfShots; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(s => long.Parse(s));
            ranges[i] = new Range(line.First(), line.Last(), true);
        }

        for (int i = NumOfShots; i < NumOfPlayers; i++)
        {
            var line = Console.ReadLine().Split(' ').Select(s => long.Parse(s));
            ranges[i] = new Range(line.First(), line.Last(), false);
        }

        ranges = ranges.OrderBy(r => r.Min).ToArray();

        PointType currentPoint = PointType.None;
        int strength = 0;
        //http://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station/
        foreach(var range in ranges)
        {

        }
        

        //int strength = 0;
        //for(int pi = 0; pi < NumOfPlayers; pi++)
        //{
        //    long[] playerRange = playersRanges[pi];
        //    for(int si = 0; si < NumOfShots; si++)
        //    {
        //        var shotRange = shotsRanges[si];
        //        if (playerRange[0] > shotRange[1] || playerRange[1] < shotRange[0])
        //            continue;
        //        strength++;
        //    }
        //}
        Console.WriteLine(strength);
    }

    struct Range
    {
        public long Max { get; set; }
        public long Min { get; set; }
        public bool IsShot { get; set; }

        public Range(long max, long min, bool isShot)
            : this()
        {
            Max = max;
            Min = min;
            IsShot = isShot;
        }
    }

    enum PointType
    {
        None = 0,
        Shot = 1,
        Player = 2,
        Overlapping = 4,
    }
}
