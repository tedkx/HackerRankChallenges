using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 2D Array - DS
/// https://www.hackerrank.com/challenges/2d-array
/// </summary>
class Solution
{
    static void Main(string[] args)
    {
        //int[][] arr = new int[6][];
        //for (int arr_i = 0; arr_i < 6; arr_i++)
        //{
        //    string[] arr_temp = Console.ReadLine().Split(' ');
        //    arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
        //}

        int[][] arr = new int[6][]
        {
            new int[] { 1, 1, 1, 0, 0, 0 },
            new int[] { 0, 1, 0, 0, 0, 0 },
            new int[] { 1, 1, 1, 0, 0, 0 },
            new int[] { 0, 9, 2, -4, -4, 0 },
            new int[] { 0, 0, 0, -2, 0, 0 },
            new int[] { 0, 0, -1, -2, -4, 0 },
        };

        var maxHourglassSum = int.MinValue;
        for(var y = 0; y < arr.Length - 2;y++)
        {
            for(var x = 0; x < arr[x].Length - 2;x++)
            {
                var sum = arr[y][x] + arr[y][x + 1] + arr[y][x + 2]
                    + arr[y + 1][x + 1]
                    + arr[y + 2][x] + arr[y + 2][x + 1] + arr[y + 2][x + 2];
                if (sum > maxHourglassSum)
                    maxHourglassSum = sum;
            }
        }

        Console.WriteLine("{0}", maxHourglassSum);
    }
}
