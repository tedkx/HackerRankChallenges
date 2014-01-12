using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChallenges.ArtificialIntelligence.BotBuilding
{
    public class BotSavesPrincess : IChallenge
    {
        public BotSavesPrincess()
        {
            Console.Write("Enter number of lines: ");
            int numLines = int.Parse(Console.ReadLine());
            Console.WriteLine("Type a " + numLines + "x" + numLines + " grid");
            string[] grid = new string[numLines];
            for (int i = 0; i < numLines; i++)
            {
                grid[i] = Console.ReadLine();
            }

            DisplayPathToPrincess(numLines, grid);
        }

        public BotSavesPrincess(string[] input)
        {
            int numLines = int.Parse(input[0]);
            string[] grid = new string[numLines];
            for (int i = 0; i < numLines; i++)
            {
                grid[i] = input[(i+1)];
            }

            DisplayPathToPrincess(numLines, grid);
        }

        protected void DisplayPathToPrincess(int n, String[] grid)
        {
            DateTime startTime = DateTime.Now;

            bool mFound = false, pFound = false;
            int[] pPos = null, mPos = null;

            for (int i = 0; i < grid.Length; i++)
            {
                if (!pFound) 
                {
                    int index = grid[i].IndexOf('p');
                    if(index > -1) {
                        pFound = true;
                        pPos = new int[] { index, i };
                    }
                }
                if (!mFound)
                {
                    int index = grid[i].IndexOf('m');
                    if (index > -1)
                    {
                        mFound = true;
                        mPos = new int[] { index, i };
                    }
                }
                if (mFound && pFound) { break; }
            }

            int leftRight = mPos[0] - pPos[0];
            if (leftRight != 0)
            {
                string direction = "LEFT";
                if (leftRight < 0) { leftRight = -leftRight; direction = "RIGHT"; }
                for (int i = 0; i < leftRight; i++) { Console.WriteLine(direction); }
            }

            int upDown = mPos[1] - pPos[1];
            if (upDown != 0)
            {
                string direction = "UP";
                if (upDown < 0) { upDown = -upDown; direction = "DOWN"; }
                for (int i = 0; i < upDown; i++) { Console.WriteLine(direction); }
            }

            Helpers.TimeScript(startTime, "Total");
        }

        public string GetName() { return "Bot Saves Princess"; }
    }
}
