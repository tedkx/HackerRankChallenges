using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1 2 3 4 5 6 7 8 9";

            int[] inputArr = input.Split(' ').Select(s => int.Parse(s)).ToArray();
            var doubleRank = Math.Sqrt(inputArr.Length);
            var rank = (int)doubleRank;
            if (doubleRank - rank > 0)
                return; //"-";


            var offset = rank;
            List<int> visitedIndices = new List<int>();
            var newArr = new int[rank][];
            for(var i = 0; i < newArr.Length;i++)
                newArr[i] = new int[rank];

            Direction direction = Direction.Left;
            int[] currentPoint = new int[] {0, 0};
            int idx = 0,
                candidateIdx = 0;
            while(true)
            {
                newArr[currentPoint[1]][currentPoint[0]] = inputArr[idx];
                visitedIndices.Add(idx);
                currentPoint[0]++;
                if(currentPoint[0] >= rank)
                {
                    currentPoint[0] = 0;
                    currentPoint[1]++;
                }                

                if (visitedIndices.Count == inputArr.Length)
                    break;

                int[] newPoint = null;
                if (direction == Direction.Right)
                {
                    candidateIdx = idx + 1;
                    currentPoint[0]++;
                    if(visitedIndices.Contains(candidateIdx))
                    {
                        direction = GetNewDirection(direction);
                        //offset--;
                    }
                }
                else if(direction == Direction.Down)
                {
                    candidateIdx = idx + offset;
                    
                }
                else if (direction == Direction.Left)
                {
                    candidateIdx = idx - 1;
                }
                else if (direction == Direction.Up)
                {
                    candidateIdx = idx - offset;
                }

                if (visitedIndices.Contains(candidateIdx))
                {
                    direction = GetNewDirection(direction);
                    if (direction == Direction.Right)
                        offset -= 2;
                }
            }

            //0 1 2
            //5 8
            //7 6
            //3
            //4
            //
            //square.Rank;
            //    toroidal = new int[square.Length];

            //var path = GetPath(square, Direction.Left, 0);

            var sb = new System.Text.StringBuilder();
            for (var i = 0; i < newArr.Length;i++ )
            {
                for(var j = 0; j < newArr[i].Length; j++)
                {
                    sb.Append(newArr[i][j].ToString());
                }
            }

                Console.WriteLine(sb.ToString());
        }

        static Direction GetNewDirection(Direction direction)
        {
            int newDirection = ((int)direction) + 1;
            if (newDirection > 4)
                newDirection = 1;
            return (Direction)newDirection;
        }


        //public IEnumerable<int> GetPath(int[] array, Direction direction, int offset)
        //{
        //    var idx = 
        //}

        public enum Direction 
        {
            Right = 1,
            Down = 2,
            Left = 3,
            Up = 4,
        }
    }
}
