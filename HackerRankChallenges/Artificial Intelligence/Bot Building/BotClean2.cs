using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChallenges.ArtificialIntelligence.BotBuilding
{
    class BotClean2: IChallenge
    {
        public BotClean2()
        {
            //String temp = Console.ReadLine();
            //String[] position = temp.Split(' ');
            //int[] pos = new int[2];
            //String[] board = new String[7];
            //for (int i = 0; i < 5; i++)
            //{
            //    board[i] = Console.ReadLine();
            //}
            //for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            //next_move(pos[0], pos[1], board);

            string[] board = { 
                "---oo",
                "-b-oo",
                "---oo",
                "ooooo",
                "ooooo"
                             };
            next_move(1, 1, board);
        }

        public string GetName() { return "BotClean Partially Observable"; }

        public void next_move(int posx, int posy, string[] board)
        {
            //if standing on dirty tile, clean and return
            if (board[posx][posy].Equals('d')) { Console.WriteLine("CLEAN"); return; }

            int[] dirty = null, distanceVector = null;
            int distance = int.MaxValue;
            //search for the nearest dirty tile
            for (int i = 0; i < board.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(board[i])) { continue; }
                string[] dirtyOccurences = board[i].Split('d');
                int prev = 0;
                for (int j = 0; j < (dirtyOccurences.Length - 1); j++)
                {
                    prev += dirtyOccurences[j].Length;
                    int tempDistance = Math.Abs(posx - i) + Math.Abs(posy - prev);
                    if (distance > tempDistance)
                    {
                        distance = tempDistance;
                        distanceVector = new int[] { posx - i, posy - prev };
                        //+ panw, - katw, + aristera, - deksia
                        dirty = new int[] { i, prev };
                    }
                    prev++;
                }
            }

            if (distanceVector == null) //no dirty found, move towards the furthest bound
            {
                int height = board.Length, length = board[0].Length, vertidistance = -1, horidistance = -1;
                string vertidir = "DOWN", horidir = "RIGHT", dir;
                if((board.Length / 2) > posx) 
                {
                    vertidistance = board.Length - posx - 1;
                }
                else if ((board.Length / 2) < posx)
                {
                    vertidir = "UP";
                    vertidistance = posx + 1;
                }
                else
                {
                    posx++;
                }
                if((board[0].Length / 2) > posy) 
                {
                    horidistance = board[0].Length - posy - 1;
                } 
                else 
                {
                    horidir = "LEFT";
                    horidistance = posy + 1;
                }
                dir = (vertidistance > horidistance) ? vertidir : horidir;
                if (vertidistance == horidistance) { dir = (new string[] { vertidir, horidir })[(new Random()).Next(2)]; }
                Console.WriteLine(dir);
            }
            else
            {
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
    }
}
