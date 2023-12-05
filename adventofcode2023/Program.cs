using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = File.ReadLines("../../TextFile1.txt").ToArray();

            int total = 0;
            double firstNum = 0;
            double secondNum = 0;

            var numberTuple = new List<(string, int)>
            {
                ("one", 1),
                ("two", 2),
                ("three", 3),
                ("four", 4),
                ("five", 5),
                ("six", 6),
                ("seven", 7),
                ("eight", 8),
                ("nine", 9),
            };

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];

                Dictionary<int, double> numsAndIndexes = new Dictionary<int, double>();

                foreach(var tuple in numberTuple)
                {
                    if (line.Contains(tuple.Item1)) {
                        List<int> foundIndexes = new List<int>();
                        int index = line.IndexOf(tuple.Item1, StringComparison.OrdinalIgnoreCase);
                        while (index != -1)
                        {
                            foundIndexes.Add(index);
                            index = line.IndexOf(tuple.Item1, index + 1, StringComparison.OrdinalIgnoreCase);
                        }
                        foreach(var ind in foundIndexes)
                        {
                            numsAndIndexes.Add(ind, tuple.Item2);
                        }
                    }
                }

                for(int j = 0; j < line.Length; j++)
                {
                    var c = line[j];
                    if (char.IsNumber(c))
                    {
                        numsAndIndexes.Add(j, char.GetNumericValue(c));
                    }
                }

                var sorted = new SortedDictionary<int, double>(numsAndIndexes);

                firstNum = sorted.Values.First();
                secondNum = sorted.Values.Last();

                var combined = Convert.ToInt32(firstNum.ToString() + secondNum.ToString());
                total += combined; 
            }

            Console.WriteLine(total);
        }
    }
}
