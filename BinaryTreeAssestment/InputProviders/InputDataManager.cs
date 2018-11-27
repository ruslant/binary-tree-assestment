using BinaryTreeAssestment.Components;
using BinaryTreeAssestment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeAssestment.InputProviders
{
    public abstract class InputDataManager : IInputDataManager
    {
        public virtual string ReadLine()
        {
            throw new NotImplementedException();
        }

        // Read data input and convert it to Node double list structure (first list for rows, second for columns)
        public List<List<Node>> ValidateInput()
        {
            var index = 0;
            var result = new List<List<Node>>();

            var values = ParseStringToNodeList(this.ReadLine());
            while (values != null)
            {
                if (values.Count() != ++index)
                {
                    throw new Exception("Provided input doesn't correspond required structure.");
                }

                result.Add(values);

                values = ParseStringToNodeList(this.ReadLine());
            }

            return result;
        }

        // Parses input string to list of nodes
        private List<Node> ParseStringToNodeList(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            var result = new List<Node>();

            var stringValues = value.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var numberString in stringValues)
            {
                if (int.TryParse(numberString, out int tempInt))
                {
                    result.Add(new Node { Value = tempInt });
                }
            }

            return result;
        }
    }
}
