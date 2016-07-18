using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Arrays DS
/// https://www.hackerrank.com/challenges/arrays-ds
/// </summary>
class Solution
{
    static void Main(string[] args)
    {
        var arrayLength = Int32.Parse(Console.ReadLine());
        var array = Console.ReadLine().Split(' ').Select(s => Int32.Parse(s)).ToArray();

        var sb = new StringBuilder();
        var i = arrayLength - 1;
        while (i >= 0)
        {
            sb.Append(array[i] + " ");
            i--;
        }
        sb.Remove(sb.Length - 1, 1);
        Console.WriteLine(sb.ToString());
        Console.ReadKey();
    }
}
