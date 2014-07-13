// <copyright file="HighScores.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The HighScores class
    /// </summary>
    public static class HighScores
    {
        /// <summary>
        /// Sorts and prints the top five chart
        /// </summary>
        /// <param name="tableToSort">Chart to be sorted and printed</param>
        public static void SortAndPrint(string[,] tableToSort)
        {
            List<Row> highScores = new List<Row>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                highScores.Add(new Row(tableToSort[i, 1], int.Parse(tableToSort[i, 0])));
            }

            highScores.Sort();

            Console.WriteLine("---------TOP FIVE Chart-----------");

            for (int i = 0; i < highScores.Count; ++i)
            {
                Row slot = highScores[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }

            Console.WriteLine("----------------------------------");
        }

        /// <summary>
        /// Checks if the current player has good enough score to go in the top five chart
        /// </summary>
        /// <param name="chart">Two dimensional array representing the top five chart</param>
        /// <param name="points">Number of point the current player has</param>
        /// <returns>Boolean variable</returns>
        public static bool IsPlayerInChart(string[,] chart, int points)
        {
            bool skilled = false;
            int worstMoves = 0;
            int worstMoveschartPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string commandInputUserName = Console.ReadLine();
                    chart[i, 0] = points.ToString();
                    chart[i, 1] = commandInputUserName;
                    skilled = true;
                    break;
                }
            }

            if (skilled == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(chart[i, 0]) > worstMoves)
                    {
                        worstMoveschartPosition = i;
                        worstMoves = int.Parse(chart[i, 0]);
                    }
                }
            }

            if (points < worstMoves && skilled == false)
            {
                Console.WriteLine("Type in your name.");
                string commandInputUserName = Console.ReadLine();
                chart[worstMoveschartPosition, 0] = points.ToString();
                chart[worstMoveschartPosition, 1] = commandInputUserName;
                skilled = true;
            }

            return skilled;
        }
    }
}
