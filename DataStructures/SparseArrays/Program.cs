using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Sparse Arrays
/// https://www.hackerrank.com/challenges/sparse-arrays
/// </summary>
class Solution
{
    static int NumOfStrings = 0;
    static int NumOfQueries = 0;

    static void Main(string[] args)
    {
        NumOfStrings = int.Parse(Console.ReadLine());

        string[] arr = new string[NumOfStrings];

        for(var i = 0; i < NumOfStrings; i++)
            arr[i] = Console.ReadLine();

        NumOfQueries = int.Parse(Console.ReadLine());

        for (var i = 0; i < NumOfQueries; i++)
        {
            var query = Console.ReadLine();
            Console.WriteLine("{0}", arr.Count(a => a == query));
        }
    }
}