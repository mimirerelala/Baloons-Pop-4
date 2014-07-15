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
    /// he ClassicalGameLogic class
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
        /// Executes method ExecuteAllCellsChecks and returns "true" if the selected element in the array is 0 
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <returns>"true" if the selected element in the array is 0 and "false" if it's not</returns>
        public override bool ModifyGameField(byte[,] gameField, int row, int col)
        {
            if (gameField[row, col] == 0)
            {
                return true;
            }

            byte searchedTarget = gameField[row, col];
            gameField[row, col] = 0;
            this.ExecuteAllCellsChecks(gameField, row, col, searchedTarget);
            return false;
        }

        /// <summary>
        /// Checks if the values of all cells in the array are equal to 0
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <returns>True if the values of all cells in the array are equal to 0 and false if they are not</returns>
        public override bool IsWinner(byte[,] gameField)
        {
            bool isWinner = true;
            Stack<byte> gamefieldStack = new Stack<byte>();
            int colLenght = gameField.GetLength(0);
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                for (int i = 0; i < colLenght; i++)
                {
                    if (gameField[i, j] != 0)
                    {
                        isWinner = false;
                        gamefieldStack.Push(gameField[i, j]);
                    }
                }

                for (int k = colLenght - 1; k >= 0; k--)
                {
                    try
                    {
                        gameField[k, j] = gamefieldStack.Pop();
                    }
                    catch (Exception)
                    {
                        gameField[k, j] = 0;
                    }
                }
            }

            return isWinner;
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
            switch (commandInput)
            {
                case "RESTART":
                    gameField = gameFieldUtility.Generate(5, 10);
                    gameFieldUtility.Print(gameField);
                    userMoves = 0;
                    break;
                case "TOP":
                    HighScores.SortAndPrint(topFive);
                    break;
                case "EXIT":
                    break;
                default:
                    ////TODO: Remove the magic numbers '0' and '9' with gameField width and height
                    if ((commandInput.Length == 3) && (commandInput[0] >= '0' && commandInput[0] <= '9') && (commandInput[2] >= '0' 
                        && commandInput[2] <= '9') && (commandInput[1] == ' ' || commandInput[1] == '.' || commandInput[1] == ','))
                    {
                        int userRow, userCol;
                        userRow = int.Parse(commandInput[0].ToString());
                        if (userRow > 4)
                        {
                            Console.WriteLine("Wrong input! Please try again!");
                            return;
                        }

                        userCol = int.Parse(commandInput[2].ToString());
                        if (gameEngine.ModifyGameField(gameField, userRow, userCol))
                        {
                            Console.WriteLine("Cannot pop a missing ballon!");
                            return;
                        }

                        userMoves++;
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

                        gameFieldUtility.Print(gameField);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Please try again!");
                        break;
                    }
            }
        }

        /// <summary>
        /// Checks if the selected element in the array is a specific searched number.
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <param name="target">The value of the element on position "[row, col]" in the array</param>
        private void CheckCell(byte[,] gameField, int row, int col, int target)
        {
            try
            {
                if (gameField[row, col] == target)
                {
                    gameField[row, col] = 0;
                    this.CheckCell(gameField, row, col, target);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine("The cell you are trying to check is out of the gamefield!");
            }
        }

        /// <summary>
        /// Checks all neighbors of the selected element in the array are a specific searched number
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <param name="target">The value of the element on position "[row, col]" in the array</param>
        private void ExecuteAllCellsChecks(byte[,] gameField, int row, int col, byte target)
        {
            this.CheckCell(gameField, row + 1, col, target);
            this.CheckCell(gameField, row - 1, col, target);
            this.CheckCell(gameField, row, col + 1, target);
            this.CheckCell(gameField, row, col - 1, target);
        }
    }
}
