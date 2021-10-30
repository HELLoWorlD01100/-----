using System.Collections.Generic;
using System.Linq;
using KA1.Domain;

namespace KA1.Service
{
    public static class JarnikPrimDijkstraAlgorithmService
    {
        public static IEnumerable<Edge> Run(IEnumerable<Edge> source)
        {
            var visitedNodes = new HashSet<int>();
            var sourceEdges = source.ToHashSet();
            var targetEdges = new HashSet<Edge>();

            var firstEdge = GetEdgeWithMinWeight(sourceEdges);
            targetEdges.Add(firstEdge);
            sourceEdges.Remove(firstEdge);
            visitedNodes.Add(firstEdge.SourceNodeNumber);
            visitedNodes.Add(firstEdge.TargetNodeNumber);
            
            while (sourceEdges.Count != 0)
            {
                var currentEdges = sourceEdges
                    .Where(x => 
                        visitedNodes.Contains(x.SourceNodeNumber) && !visitedNodes.Contains(x.TargetNodeNumber) ||
                        visitedNodes.Contains(x.TargetNodeNumber) && !visitedNodes.Contains(x.SourceNodeNumber))
                    .ToArray();
                
                if (currentEdges.Length == 0)
                    break;
                
                var currentMinEdge = GetEdgeWithMinWeight(currentEdges);
                
                targetEdges.Add(currentMinEdge);
                sourceEdges.Remove(currentMinEdge);
                visitedNodes.Add(currentMinEdge.TargetNodeNumber);
                visitedNodes.Add(currentMinEdge.SourceNodeNumber);
            }

            return targetEdges;
        }

        private static Edge GetEdgeWithMinWeight(IEnumerable<Edge> edges)
        {
            var s=  edges
                .Aggregate((x, y) => x.Weight < y.Weight ? x : y);
            return s;
        }
    }
    
    
}