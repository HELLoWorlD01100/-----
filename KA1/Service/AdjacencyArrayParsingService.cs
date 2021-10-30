using System.Collections.Generic;
using System.Linq;
using KA1.Configuration;
using KA1.Domain;

namespace KA1.Service
{
    public static class AdjacencyArrayParser
    {
        public static IEnumerable<Edge> Parse(IEnumerable<int> input)
        {
            var adjacencyArray = input.ToArray();
            var visited = new HashSet<(int, int)>();
            for (var index = 0; index < adjacencyArray.Length; index++)
            {
                var sourceNodeNumber = index + 1;
                
                var from = adjacencyArray[index] - 1;
                
                var to = adjacencyArray[index + 1] - 2;

                if (adjacencyArray[from] == Constants.EndNumber)
                    break;

                for (var i = from; i < to; i += 2)
                {
                    var weight = adjacencyArray[i + 1];
                    var targetNodeNumber = adjacencyArray[i];
                    var currentEdge = new Edge(weight, sourceNodeNumber, targetNodeNumber);
                    if (!visited.Contains((currentEdge.SourceNodeNumber, currentEdge.TargetNodeNumber)))
                        yield return currentEdge;
                    visited.Add((currentEdge.SourceNodeNumber, currentEdge.TargetNodeNumber));
                }
            }
        }
    }
}