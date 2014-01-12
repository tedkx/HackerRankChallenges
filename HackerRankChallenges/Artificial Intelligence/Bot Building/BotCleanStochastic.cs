using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChallenges.Artificial_Intelligence.Bot_Building
{
    public class BotCleanStochastic : IChallenge
    {
        public BotCleanStochastic()
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            int[] pos = new int[2];
            String[] board = new String[5];
            for (int i = 0; i < 5; i++)
            {
                board[i] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            nextMove(pos[0], pos[1], board);
        }

        static void nextMove(int posx, int posy, String[] board)
        {
            //if standing on dirty tile, clean and return

            //search for the nearest dirty tile
        }        

        public string GetName()
        {
            return "Bot Clean Stochastic";
        }
    }
}
