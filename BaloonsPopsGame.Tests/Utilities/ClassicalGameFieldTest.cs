namespace BaloonsPopsGame.Tests.Utilities
{
    using System;
    using BaloonsPopsGame.Factories;
    using BaloonsPopsGame.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassicalGameFieldTest
    {
        [TestMethod]
        public void InstanceMethodReturnsSameSingletonInstance()
        {
            var firstInstance = ClassicalGameField.Instance();
            var secondInstance = ClassicalGameField.Instance();
            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void GenerateDoesNotReturnNull()
        {
            var gameField = ClassicalGameField.Instance();
            var generatedInstance = gameField.Generate(0, 0);
            Assert.IsNotNull(generatedInstance);
        }

        [TestMethod]
        public void GenerateFillsWithOneToFiveOnly()
        {
            byte acceptableMin = 1;
            byte acceptableMax = 4;
            byte rows = 50;
            byte cols = 50;
            var gameField = ClassicalGameField.Instance();
            var generatedInstance = gameField.Generate(rows, cols);
            foreach (var cell in generatedInstance)
            {
                Assert.IsTrue(cell >= acceptableMin && cell <= acceptableMax);
            }
        }

        [TestMethod]
        public void PrintOutputsCorrectSymbols()
        {
            var currentConsoleOut = Console.Out;
            ClassicalGameField field = ClassicalGameField.Instance();

            var firstBoard = new byte[,] 
            {
                { 1, 2, 3, 4 },
                { 1, 1, 1, 1 },
                { 4, 4, 4, 4 },
            };

            var secondBoard = new byte[3, 3];

            string firstExpected = string.Format("     0  1  2  3 {0}   -------------{0}0 |  1  2  3  4 | {0}1 |  1  1  1  1 | {0}2 |  4  4  4  4 | {0}   -------------{0}", Environment.NewLine);
            string secondExpected = string.Format("     0  1  2 {0}   ----------{0}0 |          | {0}1 |          | {0}2 |          | {0}   ----------{0}", Environment.NewLine);

            using (var consoleOutput = new ConsoleOutput())
            {
                field.Print(firstBoard);
                Assert.AreEqual(firstExpected, consoleOutput.GetOuput());

                consoleOutput.ResetOutput();
                field.Print(secondBoard);
                Assert.AreEqual(secondExpected, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}
