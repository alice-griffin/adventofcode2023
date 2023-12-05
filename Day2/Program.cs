using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] games = File.ReadLines("../../TextFile1.txt").ToArray();

            int redTotal = 12;
            int greenTotal = 13;
            int blueTotal = 14;
            List<int> gameIds = new List<int>();

            int totalPwr = 0;
            for (int i = 0; i < games.Length; i++)
            {
                string game = games[i];
                bool validGame = true;

                int startIndex = game.IndexOf(" ");
                int endIndex = game.IndexOf(":");
                string gameId = game.Substring(5, endIndex - startIndex - 1);

                string gameResults = game.Substring(endIndex + 1, game.Length - endIndex - 1);

                var colorResults = gameResults.Split(';');

                int highestRed = 0;
                int highestBlue = 0;
                int highestGreen = 0;
                int numR = 0;
                int numB = 0;
                int numG = 0;
                int power = 0;

                foreach (var color in colorResults)
                {
                    var colors = color.Split(',');

                    foreach(var c in colors)
                    {
                        if (c.Contains("red"))
                        {
                            numR = Convert.ToInt32(new string(c.Where(x => char.IsNumber(x)).ToArray()));
                            if (numR > highestRed)
                            {
                                highestRed = numR;
                            }


                            if (numR > 12)
                            {
                                validGame = false;
                            }
                        }
                        if (c.Contains("blue"))
                        {
                            numB = Convert.ToInt32(new string(c.Where(x => char.IsNumber(x)).ToArray()));
                            if (numB > highestBlue)
                            {
                                highestBlue = numB;
                            }
                            if (Convert.ToInt32(numB) > 14)
                            {
                                validGame = false;
                            }

                        } 
                        if (c.Contains("green"))
                        {
                            numG = Convert.ToInt32(new string(c.Where(x => char.IsNumber(x)).ToArray()));
                            if (numG > highestGreen)
                            {
                                highestGreen = numG;
                            }

                        }
                    }
                }

                power = (highestRed * highestBlue * highestGreen);
                totalPwr += power;

                if (validGame)
                {
                    gameIds.Add(Convert.ToInt32(gameId));
                }


            }
            Console.WriteLine(totalPwr);
            int total = gameIds.Sum();

        }
    }
}
