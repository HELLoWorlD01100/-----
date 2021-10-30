using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KA1.Service
{
    public static class AdjacencyArrayReaderService
    {
        public static IEnumerable<int> ReadFromFile(string path)
        {
            var input = File.ReadLines(path);
            foreach (var line in input.Skip(1))
            {
                foreach (var number in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    yield return int.Parse(number);
            }
        }
    }
}