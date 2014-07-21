// <copyright file="ClassicalGameLogic.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Utilities
{
    ////CREATIONAL DESIGN PATTERN : SINGLETON
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The ClassicalGameLogic class
    /// </summary>
    public class ClassicalGameLogic : GameLogic
    {
        /// <summary>
        /// Keeps an instance of the <see cref="ClassicalGameLogic"/> class
        /// </summary>
        private static ClassicalGameLogic instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassicalGameLogic"/> class.
        /// </summary>
        protected ClassicalGameLogic()
        {
        }

        /// <summary>
        /// Returns the only instance of the <see cref="ClassicalGameLogic"/> class
        /// </summary>
        /// <returns>Only instance of the <see cref="ClassicalGameLogic"/> class</returns>
        public static ClassicalGameLogic Instance()
        {
            if (instance == null)
            {
                instance = new ClassicalGameLogic();
            }

            return instance;
        }

        /// <summary>
        /// Executes method CheckCells and returns "false" if the selected element in the array is 0, else return true. 
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <returns>"true" if the selected element in the array is 0 and "false" if it's not</returns>
        public override bool ModifyGameField(byte[,] gameField, int row, int col)
        {
            if (gameField[row, col] == 0)
            {
                return false;
            }

            byte searchedTarget = gameField[row, col];
            this.CheckCells(gameField, row, col, searchedTarget);
            return true;
        }

        /// <summary>
        /// Checks if the values of all cells in the array are equal to 0
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <returns>True if the values of all cells in the array are equal to 0 and false if they are not</returns>
        public override bool IsWinner(byte[,] gameField)
        {
            bool isWinner = true;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (gameField[row, col] != 0)
                    {
                        isWinner = false;
                        return isWinner;
                    }
                }
            }

            return isWinner;
        }

        /// <summary>
        /// Makes the cells fall down if there are empty cells below
        /// </summary>
        /// <param name="gameField">The game field of cells</param>
        public override void FallDown(byte[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);
            var colStack = new Stack<byte>();

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (gameField[row, col] != 0)
                    {
                        colStack.Push(gameField[row, col]);
                    }
                }

                for (int k = rows - 1; k >= 0; k--)
                {
                    if (colStack.Count > 0)
                    {
                        gameField[k, col] = colStack.Pop();
                    }
                    else
                    {
                        gameField[k, col] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Handles all user input
        /// </summary>
        /// <param name="userMoves">Count of the user's moves</param>
        /// <param name="commandInput">Current command to be executed</param>
        /// <param name="gameField">Game field represented by two dimensional array</param>
        /// <param name="gameFieldUtility">Game field generator class</param>
        /// <param name="topFive">Two dimensional array of strings</param>
        /// <param name="gameEngine">Current game logic</param>
        public override void ProcessUserInput(ref int userMoves, ref string commandInput, ref byte[,] gameField, ref GameField gameFieldUtility, ref string[,] topFive, ref GameLogic gameEngine)
        {
           commandInput = commandInput.ToUpper().Trim();

            switch (commandInput)
            {
                case "RESTART":
                    gameField = gameFieldUtility.Generate(5, 10);
                    Console.Clear();
                    gameFieldUtility.Print(gameField);
                    userMoves = 0;
                    break;
                case "TOP":
                    HighScores.SortAndPrint(topFive);
                    break;
                case "EXIT":
                    break;
                default:
                    int userRow = 0;
                    int userCol = 0;
                    bool isValidCommandLength = commandInput.Length == 3;
                    bool isValidRow = isValidCommandLength && int.TryParse(commandInput[0].ToString(), out userRow) && userRow < gameField.GetLength(0) && userRow >= 0;
                    bool isValidCol = isValidCommandLength && int.TryParse(commandInput[2].ToString(), out userCol) && userCol < gameField.GetLength(1) && userCol >= 0;
                    string validSeparators = " .,";

                    if (!(isValidCommandLength && isValidRow && isValidCol && validSeparators.Contains(commandInput[1])))
                    {
                        Console.WriteLine("Wrong input! Please try again!");
                        return;
                    }

                    bool modified = gameEngine.ModifyGameField(gameField, userRow, userCol);
                    if (!modified)
                    {
                        Console.WriteLine("Cannot pop a missing ballon!");
                        return;
                    }

                    if (gameEngine.IsWinner(gameField))
                    {
                        Console.WriteLine("Congratulations ! You have completed the game in {0} moves!", userMoves);
                        if (HighScores.IsPlayerInChart(topFive, userMoves))
                        {
                            HighScores.SortAndPrint(topFive);
                        }
                        else
                        {
                            Console.WriteLine("I am sorry, but you are not skillful enough for the TopFive chart!");
                        }

                        gameField = gameFieldUtility.Generate(5, 10);
                        userMoves = 0;
                    }
                    else
                    {
                        userMoves++;
                        gameEngine.FallDown(gameField);
                    }

                    Console.Clear();
                    gameFieldUtility.Print(gameField);
                    break;
            }
        }

        /// <summary>
        /// Checks if an array element is equal to a target: if so, set it to zero and call again with neighbours .
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <param name="target">The value searched for</param>
        private void CheckCells(byte[,] gameField, int row, int col, int target)
        {
            if (row < 0 || row >= gameField.GetLength(0))
            {
                return;
            }

            if (col < 0 || col >= gameField.GetLength(1))
            {
                return;
            }

            if (gameField[row, col] == target)
            {
                gameField[row, col] = 0;
                this.CheckCells(gameField, row + 1, col, target);
                this.CheckCells(gameField, row - 1, col, target);
                this.CheckCells(gameField, row, col + 1, target);
                this.CheckCells(gameField, row, col - 1, target);
            }
        }
    }
}
