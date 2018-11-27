using System;
using System.Collections.Generic;

namespace BinaryTreeAssestment.Components
{
    public class PathHistory : ICloneable
    {
        public int TotalSum { get; set; }
        public List<Node> NodesPath { get; set; }

        public PathHistory(int totalSum, List<Node> nodesPath)
        {
            TotalSum = totalSum;
            NodesPath = nodesPath;
        }

        public PathHistory AddNode(Node node)
        {
            TotalSum += node.Value;
            NodesPath.Add(node);

            return this;
        }

        public object Clone()
        {
            var clonedNodeList = new List<Node>(NodesPath);

            return new PathHistory(TotalSum, clonedNodeList);
        }
    }
}
