// <copyright file="GameLogic.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Linq;

    /// <summary>
    /// The abstract class GameLogic
    /// </summary>
    public abstract class GameLogic
    {
        /// <summary>
        /// Executes method ExecuteAllCellsChecks and returns "true" if the selected element in the array is 0 
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <param name="row">Row in the array</param>
        /// <param name="col">Column in the array</param>
        /// <returns>"true" if the selected element in the array is 0 and "false" if it's not</returns>
        public abstract bool ModifyGameField(byte[,] gameField, int row, int col);

        /// <summary>
        /// Checks if the values of all cells in the array are equal to 0
        /// </summary>
        /// <param name="gameField">Two dimensional array representing the game field</param>
        /// <returns>True if the values of all cells in the array are equal to 0 and false if they are not</returns>
        public abstract bool IsWinner(byte[,] gameField);

        /// <summary>
        /// Makes the cells fall down if there are empty cells below
        /// </summary>
        public abstract void FallDown(byte[,] gameField);

        /// <summary>
        /// Handles all user input
        /// </summary>
        /// <param name="userMoves">Count of the user's moves</param>
        /// <param name="commandInput">Current command to be executed</param>
        /// <param name="gameField">Game field represented by two dimensional array</param>
        /// <param name="gameFieldUtility">Game field generator class</param>
        /// <param name="topFive">Two dimensional array of strings</param>
        /// <param name="gameEngine">Current game logic</param>
        public abstract void ProcessUserInput(ref int userMoves, ref string commandInput, ref byte[,] gameField, ref GameField gameFieldUtility, ref string[,] topFive, ref GameLogic gameEngine);
    }
}
