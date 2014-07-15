namespace BaloonsPopsGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaloonsPopsGame;
    using BaloonsPopsGame.Utilities;
    using BaloonsPopsGame.Factories;

    [TestClass]
    public class GameFieldCellsFlyweightFactoryTest
    {
        [TestMethod]
        public void GetCellByValueDoesNotReturnNull()
        {
            GameFieldCell[] fieldCells = new GameFieldCell[4];

            for (int i = 1; i <= fieldCells.Length; i++)
            {
                var currentCell = GameFieldCellsFlyweightFactory.GetCellByValue(i);
                Assert.IsNotNull(currentCell);
            }
        }
    }
}
