using BinaryTreeAssestment.Components;
using BinaryTreeAssestment.InputProviders;
using System;
using System.Linq;

namespace BinaryTreeAssestment
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputDataManager = new ConsoleDataManager();

            string inputFilename = "TestInput/MainTest.txt";

            var inputDataManager = new FileDataManager(inputFilename);
            var treeManager = new TreeManager();

            var nodes = inputDataManager.ValidateInput();

            var tree = treeManager.LinkNodes(nodes);

            var path = treeManager.FindMaximumValuablePath(tree);
            if (path == null)
            {
                Console.WriteLine("Could not find any path.");
                return;
            }

            // Represent all nodes path as arrow connected strings
            var stringPath = path.NodesPath.Select(x => x.Value.ToString()).Aggregate((i, j) => $"{i} -> {j}");

            Console.WriteLine($"Max path sum: {path.TotalSum}");
            Console.WriteLine($"Nodes path: {stringPath}");

            Console.ReadLine();
        }
    }
}
