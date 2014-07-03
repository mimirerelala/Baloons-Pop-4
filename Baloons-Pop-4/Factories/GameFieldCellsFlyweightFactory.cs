namespace BaloonsPopsGame.Factories
{
    //STRUCTURAL DESIGN PATTERN : FLYWEIGHT
    using System;
    using System.Collections.Generic;
    using Utilities;

    public static class GameFieldCellsFlyweightFactory
    {
        private static Dictionary<int, GameFieldCell> flywieghtCells = new Dictionary<int,GameFieldCell>();

        static GameFieldCellsFlyweightFactory()
        {
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(1, new GameFieldCell(1, ConsoleColor.White, ConsoleColor.Red));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(2, new GameFieldCell(2, ConsoleColor.Black, ConsoleColor.Green));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(3, new GameFieldCell(3, ConsoleColor.White, ConsoleColor.Blue));
            GameFieldCellsFlyweightFactory.flywieghtCells.Add(4, new GameFieldCell(4, ConsoleColor.Black, ConsoleColor.Yellow));
        }

        public static GameFieldCell GetCellByValue(int value)
        {
            return GameFieldCellsFlyweightFactory.flywieghtCells[value];
        }
    }
}
