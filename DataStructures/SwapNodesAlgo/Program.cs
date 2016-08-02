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
        Node tree = NumOfNodes == 0 ? null : new Node(1);
        int currentDepth = 2;
        for (var i = 0; i < NumOfNodes; i++)
        {
            var line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            while (!AppendToTree(tree, currentDepth, 1, line[0], line[1]))
                currentDepth++;
        }

        int NumOfSwaps = int.Parse(Console.ReadLine());
        for (var i = 0; i < NumOfSwaps; i++)
        {
            int initialDepth = int.Parse(Console.ReadLine()),
                depth = initialDepth;
            while (Swap(tree, depth, 1))
                depth += initialDepth;
            InorderPrint(tree);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Appends left and right data to a node at the desired depth. returns true if children created and false if not
    /// </summary>0
    /// <returns></returns>
    static bool AppendToTree(Node node, int desiredDepth, int currentDepth, int dataLeft, int dataRight)
    {
        bool result = false;
        if ((currentDepth + 1) == desiredDepth)
        {
            if (node.CreatedChildren)
                return false;
            if (node.Left == null && dataLeft != -1)
                node.Left = new Node(dataLeft);
            if (node.Right == null && dataRight != -1)
                node.Right = new Node(dataRight);
            result = true;
            node.CreatedChildren = true;
        }
        else
        {
            if (node.Left != null)
                result = AppendToTree(node.Left, desiredDepth, currentDepth + 1, dataLeft, dataRight);
            if (!result && node.Right != null)
                result = AppendToTree(node.Right, desiredDepth, currentDepth + 1, dataLeft, dataRight);
        }
        return result;
    }

    /// <summary>
    /// Swaps the children of nodes at the desired depth. Returns true if any swap performed, false otherwise
    /// </summary>
    static bool Swap(Node node, int desiredDepth, int currentDepth)
    {
        bool result = false;
        if (currentDepth == desiredDepth)
        {
            var temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;
            result = true;
        }
        else if (currentDepth < desiredDepth)
        {
            if (node.Left != null)
                result = Swap(node.Left, desiredDepth, currentDepth + 1);
            if (node.Right != null)
                result = Swap(node.Right, desiredDepth, currentDepth + 1) || result;
        }
        return result;
    }

    static void InorderPrint(Node node)
    {
        if (node.Left != null)
            InorderPrint(node.Left);
        Console.Write("{0} ", node.Data);
        if (node.Right != null)
            InorderPrint(node.Right);
    }
}

class Node
{
    public int Data;
    public Node Left;
    public Node Right;
    public bool CreatedChildren;

    public Node(int data)
    {
        Data = data;
    }
}