using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Bot saves princess - 2
/// https://www.hackerrank.com/challenges/saveprincess2
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        int n;

        n = int.Parse(Console.ReadLine());
        String pos;
        pos = Console.ReadLine();
        String[] position = pos.Split(' ');
        int[] int_pos = new int[2];
        int_pos[0] = Convert.ToInt32(position[0]);
        int_pos[1] = Convert.ToInt32(position[1]);
        String[] grid = new String[n];
        for (int i = 0; i < n; i++)
        {
            grid[i] = Console.ReadLine();
        }

        nextMove(n, int_pos[0], int_pos[1], grid);
    }

    static void nextMove(int n, int r, int c, String[] grid)
    {
        int[] mpos = { r, c };
        int[] ppos = null;

        for (int i = 0; i < grid.Length; i++)
        {
            int index = grid[i].IndexOf('p');
            if (index > -1)
            {
                ppos = new int[] { i, index };
                break;
            }
        }

        int leftRight = mpos[1] - ppos[1];
        if (leftRight != 0)
        {
            string direction = "LEFT";
            if (leftRight < 0) { leftRight = -leftRight; direction = "RIGHT"; }
            Console.WriteLine(direction);
            return;
        }

        int upDown = mpos[0] - ppos[0];
        if (upDown != 0)
        {
            string direction = "UP";
            if (upDown < 0) { upDown = -upDown; direction = "DOWN"; }
            Console.WriteLine(direction);
            return;
        }
    }
}

