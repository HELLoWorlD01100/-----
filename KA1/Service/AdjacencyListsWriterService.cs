using System.Collections.Generic;
using System.IO;
using System.Linq;
using KA1.Domain;

namespace KA1.Service
{
    public static class AdjacencyListsWriterService
    {
        public static void Write(string path, IEnumerable<Edge> sourceEdges)
        {
            var enumerable = sourceEdges as Edge[] ?? sourceEdges.ToArray();
            
            var totalWeight = enumerable.Sum(x => x.Weight);
            var adjacencyLists = GetAdjacencyLists(enumerable);
            using var stream = new StreamWriter(path);
            foreach (var (currentNodeNumber, adjacencyNodesNumbers) in adjacencyLists)
            {
                var line = $"{currentNodeNumber}    {string.Join(' ', adjacencyNodesNumbers.OrderBy(x => x))} 0";
                stream.WriteLine(line);
            }

            stream.WriteLine(totalWeight);
        }

        private static IDictionary<int, ISet<int>> GetAdjacencyLists(IEnumerable<Edge> source)
        {
            var nodes = source
                .GroupBy(x => x.SourceNodeNumber)
                .ToDictionary(x => x.Key,
                    x => x.Select(y => y.TargetNodeNumber));

            var result = new Dictionary<int, ISet<int>>();
            foreach (var (currentNodeNumber, incidentNodes) in nodes)
            {
                if (!result.ContainsKey(currentNodeNumber))
                    result[currentNodeNumber] = new HashSet<int>();

                result[currentNodeNumber].UnionWith(nodes.ContainsKey(currentNodeNumber)
                    ? nodes[currentNodeNumber]
                    : Enumerable.Empty<int>());

                foreach (var incidentNode in incidentNodes)
                {
                    if (!result.ContainsKey(incidentNode))
                        result[incidentNode] = new HashSet<int>();

                    result[incidentNode].Add(currentNodeNumber);
                }
            }

            return result;
        }
    }
}