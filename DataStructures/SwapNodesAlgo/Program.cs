using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Swap Nodes [Algo]
/// https://www.hackerrank.com/challenges/swap-nodes-algo
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        int NumOfNodes = int.Parse(Console.ReadLine());
    }
}

class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
    }
}