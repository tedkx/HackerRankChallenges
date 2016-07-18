using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    /// <summary>
    /// Candles Counting
    /// https://www.hackerrank.com/challenges/candles-2
    /// </summary>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        bool dataFromConsole = false;
        int candlesCount,
            colorsCount;
        Candle[] candles = null;

        //parse data
        if (dataFromConsole)
        {
            var data = Console.ReadLine().Split(' ');
            candlesCount = Int32.Parse(data[0]);
            colorsCount = Int32.Parse(data[1]);
            candles = new Candle[candlesCount];
            for (int i = 0; i < candlesCount; i++)
            {
                var candleData = Console.ReadLine().Split(' ');
                candles[i] = new Candle(Int32.Parse(candleData[0]), Int32.Parse(candleData[1]));
            }
        }
        else
        {
            candles = ParseResource(out candlesCount, out colorsCount);
        }

        candles = candles.OrderBy(c => c.Height).ToArray();

        Int64 subsequencesCount = 0;

        Action<int> findSequences = (int startIdx) =>
        {
            Console.WriteLine("Checking candle {0} of {1}", startIdx + 1, candlesCount);
            //Console.CursorTop--;
            var startCandle = candles[startIdx];
            var tree = new Tree(colorsCount, startCandle);

            for (var x = startIdx + 1; x < candlesCount; x++)
            {
                
                tree.TryInsert(candles[x]);
            }

            subsequencesCount += tree.CountLeaves();
        };

        //1 2 3 4 5 6

        //56 4 [5,6]
        
        //    64 5 [6]

        var allColors = Enumerable.Range(1, colorsCount).ToArray();
        for(var i = 0; i < candlesCount - (colorsCount - 1); i++)
        {
            //var idx = i;
            Console.WriteLine("Checking candle {0} of {1}", i + 1, candlesCount);
            //var lst = new List<Candle[]>();
            //var startCandle = candles[i];

            subsequencesCount += GetCount(candles, i, allColors);
        }

        Console.CursorTop += 2;
        Console.WriteLine("{0}", FormatResult(subsequencesCount));
        Console.ReadKey();
    }

    static int GetCount(Candle[] candles, int index, int[] permittedColors) {
        if (index >= candles.Length)
            return 0;
        var sum = 0;
        var candle = candles[index];
        var newPermittedColors = permittedColors.Where(p => candle.Color != p).ToArray();
        if (newPermittedColors.Length == 0)
            return 1;
        List<System.Threading.Tasks.Task> tasks = new List<System.Threading.Tasks.Task>();
        for (var i = index + 1; i < candles.Length; i++)
        {
            
            if(newPermittedColors.Contains(candles[i].Color))
                tasks.Add(System.Threading.Tasks.Task.Run(() => {
                    sum += GetCount(candles, i, newPermittedColors);
                }));
            //Console.WriteLine("Finished with index {0}", index);
            //Console.CursorTop--;
        }
        System.Threading.Tasks.Task.WaitAll(tasks.ToArray(), 30000);
        return sum;
    }

    static Candle[] ParseResource(out int candlesCount, out int colorsCount, string resourceName = "TestCase4")
    {
        var lst = new List<Candle>();
        using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("CandlesCounting.{0}.txt", resourceName)))
        {
            using (var streamReader = new StreamReader(stream))
            {
                var firstLine = streamReader.ReadLine().Split(' ');
                candlesCount = Int32.Parse(firstLine[0]);
                colorsCount = Int32.Parse(firstLine[1]);
                var i = 1;
                while (streamReader.Peek() >= 0)
                {
                    var line = streamReader.ReadLine().Split(' ');
                    lst.Add(new Candle(Int32.Parse(line[0]), Int32.Parse(line[1])));
                    Console.WriteLine("Read line {0}", i);
                    Console.CursorTop--;
                    i++;
                }
            }
        }
        Console.CursorTop += 2;
        return lst.ToArray();
    }

    static bool breaksSequence(Candle candle, Candle? previousCandle, int[] subsequenceColors)
    {
        if (!previousCandle.HasValue)
            return false;
        return !subsequenceColors.Contains(candle.Color) && previousCandle.Value.Height < candle.Height;
    }

    static Int64 FormatResult(Int64 sequencesCount)
    {
        return sequencesCount % ((10 ^ 9) + 7);
    }

    struct Candle
    {
        public int Height { get; set; }
        public int Color { get; set; }

        public Candle(int height, int color)
            : this()
        {
            this.Height = height;
            this.Color = color;
        }
    }

    class Tree
    {
        public int ColorCount { get; private set; }

        public Tree(int colorCount, Candle candle)
        {
            Root = new Node(candle, 1);
            ColorCount = colorCount;
        }
        public Node Root { get; private set; }
        public void TryInsert(Candle candle)
        {
            this.Root.TryInsert(candle, ColorCount);
        }
        public int CountLeaves()
        {
            return this.Root.CountLeaves(ColorCount);
        }
    }

    class Node
    {
        public List<Node> Children { get; private set; }
        bool IsLeaf { get { return Children.Count == 0; } }
        public Candle Candle { get; private set; }
        private int Depth { get; set; }
        public Node Parent { get; private set; }

        public Node(Candle candle, int depth)
        {
            Children = new List<Node>();
            Candle = candle;
            Depth = depth;
        }

        public void TryInsert(Candle candle, int maxDepth)
        {
            if (this.Depth >= maxDepth)
                return;
            if (this.Candle.Color == candle.Color)
                return;
            if (this.Candle.Height >= candle.Height)
                return;

            Children.Add(new Node(candle, this.Depth + 1));

            if (maxDepth <= this.Depth)
                return;

            foreach (var ch in Children)
                ch.TryInsert(candle, maxDepth);
        }

        public int CountLeaves(int depth)
        {
            if (this.IsLeaf)
                return this.Depth == depth ? 1 : 0;

            return Children.Sum(c => c.CountLeaves(depth));
        }
    }
}