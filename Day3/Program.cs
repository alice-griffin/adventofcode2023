using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] contents = File.ReadLines("../../TextFile1.txt").ToArray();

            string lineBefore = "";
            string lineAfter = "";

            string pattern = @"[*\/@$=%+\-]";

            List<string> engineParts = new List<string>();

            Regex regex = new Regex(pattern);

            for (int i = 0; i < contents.Length; i++)
            {
                string currentLine = contents[i];

                for(int j = 0; j < currentLine.Length; j++)
                {
                    char currentCharacter = currentLine[j];
                    Match match = regex.Match(currentCharacter.ToString());
                    if (match.Success)
                    {
                        int matchIndex = currentLine.IndexOf(currentCharacter);
                        //find all adjacent numbers
                        lineBefore = contents[i - 1];
                        lineAfter = contents[i + 1];

                        if (i != 0)
                        {
                            if (Char.IsDigit(lineAfter[matchIndex]))
                            {
                                //first search to the left, prepending numbers
                                string searchString = Reverse(lineAfter.Substring(0, matchIndex));
                                string numberToAdd = "";
                                foreach (var s in searchString)
                                {
                                    if (Char.IsDigit(s))
                                    {
                                        numberToAdd += s;
                                        numberToAdd = Reverse(numberToAdd);
                                    }

                                    if (s == '.')
                                    {
                                        break;
                                    }
                                }

                                searchString = lineAfter.Substring(matchIndex, lineBefore.Length - 1);
                                foreach (var s in searchString)
                                {
                                    if (Char.IsDigit(s))
                                    {
                                        numberToAdd += s;
                                    }

                                    if (s == '.')
                                    {
                                        break;
                                    }
                                }
                                engineParts.Add(numberToAdd);
                            } 
                            else
                            {
                                if (Char.IsDigit(lineAfter[matchIndex - 1]))
                                {
                                    string searchString = Reverse(lineAfter.Substring(0, matchIndex));
                                    string numberToAdd = "";

                                    foreach (var s in searchString)
                                    {
                                        if (Char.IsDigit(s))
                                        {
                                            numberToAdd += s;
                                        }

                                        if (s == '.')
                                        {
                                            break;
                                        }
                                    }
                                    engineParts.Add(numberToAdd);
                                }

                                if (Char.IsDigit(lineAfter[matchIndex + 1]))
                                {
                                    string searchString = lineAfter.Substring(matchIndex, lineAfter.Length - 1);
                                    string numberToAdd = "";

                                    foreach (var s in searchString)
                                    {
                                        if (Char.IsDigit(s))
                                        {
                                            numberToAdd += s;
                                        }

                                        if (s == '.')
                                        {
                                            break;
                                        }
                                    }
                                    engineParts.Add(numberToAdd);
                                }
                            }

                            if (Char.IsDigit(lineBefore[matchIndex]))
                            {
                                //first search to the left, prepending numbers
                                string searchString = Reverse(lineBefore.Substring(0, matchIndex));
                                string numberToAdd = "";
                                foreach(var s in searchString)
                                {
                                    if (Char.IsDigit(s))
                                    {
                                        numberToAdd += s;
                                        numberToAdd = Reverse(numberToAdd);
                                    }

                                    if (s == '.')
                                    {
                                        break;
                                    }
                                }
                                searchString = lineBefore.Substring(matchIndex, lineBefore.Length - 1);
                                foreach(var s in searchString)
                                {
                                    if (Char.IsDigit(s))
                                    {
                                        numberToAdd += s;
                                    }

                                    if (s == '.')
                                    {
                                        break;
                                    }
                                }
                                engineParts.Add(numberToAdd);
                            }
                            else
                            {
                                if (Char.IsDigit(lineBefore[matchIndex - 1]))
                                {
                                    string searchString = Reverse(lineBefore.Substring(0, matchIndex));
                                    string numberToAdd = "";

                                    foreach (var s in searchString)
                                    {
                                        if (Char.IsDigit(s))
                                        {
                                            numberToAdd += s;
                                        }

                                        if (s == '.')
                                        {
                                            break;
                                        }
                                    }
                                    engineParts.Add(numberToAdd);
                                }

                                if (Char.IsDigit(lineBefore[matchIndex + 1]))
                                {
                                    string searchString = lineBefore.Substring(matchIndex, lineBefore.Length - 1);
                                    string numberToAdd = "";

                                    foreach (var s in searchString)
                                    {
                                        if (Char.IsDigit(s))
                                        {
                                            numberToAdd += s;
                                        }

                                        if (s == '.')
                                        {
                                            break;
                                        }
                                    }
                                    engineParts.Add(numberToAdd);
                                }
                            }

                        }
                    }
                }
                //int total = engineParts.Sum();
            }

            Console.WriteLine();
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

}
