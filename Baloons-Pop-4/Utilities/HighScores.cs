﻿// <copyright file="HighScores.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
// <summary>The HighScores class</summary>
namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The HighScores class.
    /// </summary>
    public static class HighScores
    {
        /// <summary>
        /// Sorts and prints the top five chart.
        /// </summary>
        /// <param name="tableToSort">Chart to be sorted and printed.</param>
        public static void Print(string[,] tableToSort)
        {
            List<Row> highScores = new List<Row>();
            int highScoreRowCounter = 5;
            int highScoreColCounter = 1;

            for (int i = 0; i < highScoreRowCounter; ++i)
            {
                if (tableToSort.GetLength(0) < highScoreRowCounter || tableToSort[i, 0] == null)
                {
                    break;
                }

                if (tableToSort.GetLength(1) < highScoreColCounter)
                {
                    highScores.Add(new Row(tableToSort[i, highScoreColCounter], int.Parse(tableToSort[i, 0])));
                }
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
        /// Saves a chart to a text file by a give file path.
        /// </summary>
        /// <param name="chart">Top five chart array.</param>
        /// <param name="filePath">Path to which the file will be saved.</param>
        public static void Save(string[,] chart, string filePath)
        {
            StreamWriter scoresFile = new StreamWriter(filePath);

            using (scoresFile)
            {
                // Save the dimention of the array
                scoresFile.WriteLine(chart.GetLength(0));
                scoresFile.WriteLine(chart.GetLength(1));

                for (int row = 0; row < chart.GetLength(0); row++)
                {
                    for (int col = 0; col < chart.GetLength(1); col++)
                    {
                        scoresFile.WriteLine(chart[row, col]);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a chart from a file and returns it.
        /// </summary>
        /// <param name="filePath">Path to the saved chart.</param>
        /// <returns>The array of bes players.</returns>
        public static string[,] Load(string filePath)
        {
            string[,] chart;

            StreamReader scoresFile = new StreamReader(filePath);

            using (scoresFile)
            {
                int chartPropertyCount = Convert.ToInt32(scoresFile.ReadLine());
                int chartMembersCount = Convert.ToInt32(scoresFile.ReadLine());

                chart = new string[chartPropertyCount, chartMembersCount];
                string currentChartCell;

                for (int i = 0; i < chart.GetLength(0); i++)
                {
                    for (int k = 0; k < chart.GetLength(1); k++)
                    {
                        currentChartCell = scoresFile.ReadLine();
                        
                        if (currentChartCell == string.Empty)
                        {
                            chart[i, k] = null;
                        }
                        else
                        {
                            chart[i, k] = currentChartCell;
                        }                         
                    }
                }
            }

            return chart;
        }

        /// <summary>
        /// Checks if the current player has good enough score to go in the top five chart.
        /// </summary>
        /// <param name="chart">Two dimensional array representing the top five chart.</param>
        /// <param name="points">Number of point the current player has.</param>
        /// <returns>Boolean variable.</returns>
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
