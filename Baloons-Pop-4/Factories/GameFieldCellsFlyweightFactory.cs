// <copyright file="GameFieldCellsFlyweightFactory.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
// <summary>The GameFieldCellsFlyweightFactory class</summary>
namespace BaloonsPopsGame.Factories
{
    ////STRUCTURAL DESIGN PATTERN : FLYWEIGHT
    using System;
    using System.Collections.Generic;
    using Utilities;

    /// <summary>
    /// The GameFieldCellsFlyweightFactory class.
    /// </summary>
    public static class GameFieldCellsFlyweightFactory
    {
        /// <summary>
        /// Dictionary containing information about the colors of all cell with different values.
        /// </summary>
        private static Dictionary<int, GameFieldCell> flywieghtCells = new Dictionary<int, GameFieldCell>();

        /// <summary>
        /// Initializes static members of the <see cref="GameFieldCellsFlyweightFactory"/> class.
        /// </summary>
        static GameFieldCellsFlyweightFactory()
        {
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(1, new GameFieldCell(1, ConsoleColor.White, ConsoleColor.Red));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(2, new GameFieldCell(2, ConsoleColor.Black, ConsoleColor.Green));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(3, new GameFieldCell(3, ConsoleColor.White, ConsoleColor.Blue));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(4, new GameFieldCell(4, ConsoleColor.Black, ConsoleColor.Yellow));
        }

        /// <summary>
        /// Returns a <see cref="GameFieldCell"/> by it's value.
        /// </summary>
        /// <param name="value">Value of the searched cell.</param>
        /// <returns>A <see cref="GameFieldCell"/> by it's value.</returns>
        public static GameFieldCell GetCellByValue(int value)
        {
            return GameFieldCellsFlyweightFactory.flywieghtCells[value];
        }
    }
}
