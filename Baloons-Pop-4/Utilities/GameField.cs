// <copyright file="GameField.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Linq;

    /// <summary>
    /// The abstract class GameField
    /// </summary>
    public abstract class GameField
    {
        /// <summary>
        /// Abstract method
        /// </summary>
        /// <param name="rows">Number of rows of the array</param>
        /// <param name="cols">Number of columns of the array</param>
        /// <returns>A two dimensional array</returns>
        public abstract byte[,] Generate(byte rows, byte cols);

        /// <summary>
        /// Visualizes a two dimensional array
        /// </summary>
        /// <param name="field">A two dimensional array</param>
        public abstract void Print(byte[,] field);
    }
}
