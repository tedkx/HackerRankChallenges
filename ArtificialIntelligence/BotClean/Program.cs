using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Bot Clean
/// https://www.hackerrank.com/challenges/botclean
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        string temp = Console.ReadLine();
        string[] position = temp.Split(' ');
        int[] pos = new int[2];
        string[] board = new string[5];
        for (int i = 0; i < 5; i++)
        {
            board[i] = Console.ReadLine();
        }
        for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
        next_move(pos[0], pos[1], board);
    }

    static void next_move(int posr, int posc, string[] board)
    {
        //if standing on dirty tile, clean and return
        if (board[posr][posc].Equals('d')) { Console.WriteLine("CLEAN"); return; }

        int[] dirty = null, distanceVector = null;
        int distance = int.MaxValue;
        //search for the nearest dirty tile
        for (int i = 0; i < board.Length; i++)
        {
            string[] dirtyOccurences = board[i].Split('d');
            int prev = 0;
            for (int j = 0; j < (dirtyOccurences.Length - 1); j++)
            {
                prev += dirtyOccurences[j].Length;
                int tempDistance = Math.Abs(posr - i) + Math.Abs(posc - prev);
                if (distance > tempDistance)
                {
                    distance = tempDistance;
                    distanceVector = new int[] { posr - i, posc - prev };
                    //+ panw, - katw, + aristera, - deksia
                    dirty = new int[] { i, prev };
                }
                prev++;
            }
        }

        if (Math.Abs(distanceVector[0]) > Math.Abs(distanceVector[1]) && distanceVector[0] != 0)
        {
            Console.WriteLine((distanceVector[0] < 0) ? "DOWN" : "UP");
        }
        else
        {
            Console.WriteLine((distanceVector[1] < 0) ? "RIGHT" : "LEFT");
        }

    }
}
