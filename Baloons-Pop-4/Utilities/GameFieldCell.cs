// <copyright file="GameFieldCell.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
// <summary>The GameFieldCell class</summary>
namespace BaloonsPopsGame.Utilities
{
    using System;

    /// <summary>
    /// The GameFieldCell class.
    /// </summary>
    public class GameFieldCell
    {
        /// <summary>
        /// Integer value in the cell.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// The foreground color of the cell.
        /// </summary>
        private readonly ConsoleColor foregroundColor;

        /// <summary>
        /// The background color of the cell.
        /// </summary>
        private readonly ConsoleColor backgroundColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameFieldCell"/> class.
        /// </summary>
        /// <param name="value">Integer value in the cell.</param>
        /// <param name="foregroundColor">The foreground color of the cell.</param>
        /// <param name="backgroundColor">The background color of the cell.</param>
        public GameFieldCell(int value, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.value = value;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
        }

        /// <summary>
        /// Visualizes the cell.
        /// </summary>
        public void Draw()
        {
            Console.ForegroundColor = this.foregroundColor;
            Console.BackgroundColor = this.backgroundColor;

            Console.Write(" " + this.value + " ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
