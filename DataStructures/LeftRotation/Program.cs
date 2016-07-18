using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Left Rotation
/// https://www.hackerrank.com/challenges/array-left-rotation
/// </summary>
class Solution
{
    static long[] Array = null;
    static void Main(string[] args)
    {
        var data = Console.ReadLine().Split(' ');
        int numOfIntegers = int.Parse(data[0]);
        int numOfRotations = int.Parse(data[1]);

        Array = Console.ReadLine().Split(' ').Select(s => long.Parse(s)).ToArray();

        if(numOfRotations > Array.Length)
            numOfRotations = numOfRotations - Array.Length;
        var rotationsArray = Array.Take(numOfRotations).ToArray();

        for (var i = 0; i < Array.Length - numOfRotations; i++)
            Array[i] = Array[i + numOfRotations];

        int rotationsArrayIdx = 0;
        for (var i = Array.Length - numOfRotations; i < Array.Length; i++)
        {
            Array[i] = rotationsArray[rotationsArrayIdx];
            rotationsArrayIdx++;
        }

        Console.WriteLine("{0}", string.Join(" ", Array));

        // [0,1,2,3,4,5,6], rot 4, rotArr = [0,1,2,3]
        // [4,5,6,
    }

    static void RotateLeft()
    {
        long first = Array[0];
        for (var i = 0; i < Array.Length - 1; i++)
            Array[i] = Array[i + 1];
        Array[Array.Length - 1] = first;
    }
}
