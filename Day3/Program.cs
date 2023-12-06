using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] contents = File.ReadLines("../../TextFile1.txt").ToArray();

            string previousLine = "";
            string nextLine = "";

            for(int i = 0; i < contents.Length; i+=2)
            {
                var line = contents[i];
                Console.WriteLine(i);

                
            }

            Console.WriteLine();
        }
    }
}
