using System.Linq;
using KA1.Configuration;
using KA1.Service;

namespace KA1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var adjacencyArray = AdjacencyArrayReaderService.ReadFromFile(Constants.InputFile).ToArray();
            var edges = AdjacencyArrayParser.Parse(adjacencyArray).ToArray();
            var result = JarnikPrimDijkstraAlgorithmService.Run(edges).ToArray();
            AdjacencyListsWriterService.Write(Constants.OutputFile, result);
        }
    }
}