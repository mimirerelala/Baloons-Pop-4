namespace BaloonsPopsGame.Tests
{
    using System;
    using BaloonsPopsGame;
    using BaloonsPopsGame.Factories;
    using BaloonsPopsGame.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldCellsFlyweightFactoryTest
    {
        [TestMethod]
        public void GetCellByValueDoesNotReturnNullWithValuesOneToFour()
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
