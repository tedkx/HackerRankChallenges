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
        var lines = ParseResourceAsInputLines("mytestcase");
        //var firstLine = Console.ReadLine().Split(' ');
        var firstLine = lines.Dequeue().Split(' ');
        NumOfShots = int.Parse(firstLine[0]);
        NumOfPlayers = int.Parse(firstLine[1]);
        //short[] points = new short[(NumOfPlayers + NumOfShots) * 2];
        var dic = new Dictionary<long, PointData>();

        long maxValue = 0;
        for (int i = 0; i < NumOfShots; i++)
        {
            //var line = Console.ReadLine().Split(' ').Select(s => long.Parse(s));
            var line = lines.Dequeue().Split(' ').Select(s => long.Parse(s));
            long low = line.First(),
                high = line.Last();

            if (!dic.ContainsKey(low))
                dic[low] = new PointData(PointType.ShotStart);
            else
                dic[low].Increment(PointType.ShotStart);

            if (!dic.ContainsKey(high))
                dic[high] = new PointData(PointType.ShotEnd);
            else
                dic[high].Increment(PointType.ShotEnd);

            if(maxValue < high)
                maxValue = high;
        }

        for (int i = NumOfShots; i < NumOfShots + NumOfPlayers; i++)
        {
            //var line = Console.ReadLine().Split(' ').Select(s => long.Parse(s));
            var line = lines.Dequeue().Split(' ').Select(s => long.Parse(s));
            long low = line.First(),
                high = line.Last();

            if (!dic.ContainsKey(low))
                dic[low] = new PointData(PointType.PlayerStart);
            else
                dic[low].Increment(PointType.PlayerStart);

            if (!dic.ContainsKey(high))
                dic[high] = new PointData(PointType.PlayerEnd);
            else
                dic[high].Increment(PointType.PlayerEnd);

            if(maxValue < high)
                maxValue = high;
        }

        int strength = 0,
            currentPlayersCount = 0,
            currentShotsCount = 0;

        var points = new PointData[maxValue + 1];
        foreach(var pair in dic)
            points[pair.Key] = pair.Value;
        
        for (var i = 0; i < points.Length; i++)
        {
            var currentPoint = points[i];
            if (currentPoint == null)
                continue;

            if (currentPoint.Contains(PointType.ShotStart))
            {
                currentShotsCount += currentPoint.ShotStartCount;
                strength += currentPlayersCount * currentPoint.ShotStartCount;
            }
            if (currentPoint.Contains(PointType.PlayerStart))
            {
                currentPlayersCount += currentPoint.PlayerStartCount;
                strength += currentShotsCount * currentPoint.PlayerStartCount;
            }

            if (currentPoint.Contains(PointType.ShotEnd))
                currentShotsCount -= currentPoint.ShotEndCount;
            if (currentPoint.Contains(PointType.PlayerEnd))
                currentPlayersCount -= currentPoint.PlayerEndCount;
        }

        Console.WriteLine(strength);
    }

    enum PointType
    {
        None = 0,
        PlayerStart = 1,
        PlayerEnd = 2,
        PlayerStartEnd = 3,
        ShotStart = 4,
        PlayerShotStart = 5,
        PlayerEndShotStart = 6,
        PlayerStartEndShotStart = 7,
        ShotEnd = 8,
        PlayerStartShotEnd = 9,
        PlayerEndShotEnd = 10,
        PlayerStartEndShotEnd = 11,
        ShotStartEnd = 12,
        PlayerStartShotStartEnd = 13,
        PlayerEndShotStartEnd = 14,
        PlayerStartEndShotStartEnd = 15,
    }

    class PointData
    {
        public PointType Type { get; set; }
        public short ShortType { get; set; }
        public int ShotStartCount { get; set; }
        public int ShotEndCount { get; set; }
        public int PlayerStartCount { get; set; }
        public int PlayerEndCount { get; set; }

        public PointData(PointType type)
        {
            Type = type;
            ShortType = (short)type;
            Increment(type);
        }

        private void SetType(PointType type)
        {
            ShortType += (short)type;
            Type = (PointType)ShortType;
        }

        public void Increment(PointType type)
        {
            if (!Contains(type))
                SetType(type);
            switch(type)
            {
                case PointType.ShotStart: ShotStartCount++; break;
                case PointType.ShotEnd: ShotEndCount++; break;
                case PointType.PlayerStart: PlayerStartCount++; break;
                case PointType.PlayerEnd: PlayerEndCount++; break;
            }
        }

        public bool Contains(PointType testType)
        {
            return ((ShortType & (short)testType) != 0);
        }
    }

    static Queue<string> ParseResourceAsInputLines(string resourceName = "testcase1")
    {
        string resourceFormat = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name.Replace(".exe", string.Empty) + ".{0}.txt";            
        var queue = new Queue<string>();
        using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format(resourceFormat, resourceName)))
            using (var streamReader = new StreamReader(stream))
                while (streamReader.Peek() >= 0)
                    queue.Enqueue(streamReader.ReadLine());
        return queue;
    }
}
