using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeAssestment.Components
{
    public class TreeManager
    {
        // Function accept array of data, process nodes to tree structure
        // Returns root node
        public Node LinkNodes(List<List<Node>> data)
        {
            // Starting from the second row
            // Row nodes will be assigned as childs to parent node (row - 1)
            for (var rowNr = 1; rowNr < data.Count(); rowNr++)
            {
                for (var colNr = 0; colNr < rowNr; colNr++)
                {
                    // Parent row node
                    var node = data[rowNr - 1][colNr];

                    // Assign left node
                    node.LeftNode = data[rowNr][colNr];

                    // Assign right node
                    node.RightNode = data[rowNr][colNr + 1];
                }
            }

            // Return root node
            return data[0][0];
        }

        // Function searches for maximum valuable path and returns best result
        public PathHistory FindMaximumValuablePath(Node rootNode)
        {
            if (rootNode == null)
            {
                throw new Exception("Root node is not provided.");
            }

            var rootPathHistory = new PathHistory(0, new List<Node>());

            var paths = TraverseBinaryTree(rootNode, CheckIsEven(rootNode.Value), rootPathHistory);

            return paths.OrderByDescending(x => x.TotalSum).FirstOrDefault();
        }

        // Recursion function that allow to explore tree pathes.
        private List<PathHistory> TraverseBinaryTree(Node node, bool isEven, PathHistory pathHistory)
        {
            var result = new List<PathHistory>();

            // Escape criteria
            if (node == null || CheckIsEven(node.Value) != isEven)
            {
                result.Add(pathHistory);

                return result;
            }

            // Registerig visited node
            pathHistory.AddNode(node);

            // Run traverse recursive function for left child
            var leftNodeResult = TraverseBinaryTree(node.LeftNode, !isEven, (PathHistory)pathHistory.Clone());
            // Run traverse recursive function for the right child
            var rightNodeResult = TraverseBinaryTree(node.RightNode, !isEven, (PathHistory)pathHistory.Clone());

            // Saving results
            result.AddRange(leftNodeResult);
            result.AddRange(rightNodeResult);
            
            // Return
            return result;
        }

        private bool CheckIsEven(int value)
        {
            return (value % 2) == 0;
        }
    }
}
