namespace BaloonsPopsGame.Tests
{
    using BaloonsPopsGame.Factories;
    using BaloonsPopsGame.Utilities;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaloonsPopsGame.Tests.Utilities;

    [TestClass]
    public class ClassicalGameLogicTest
    {
        [TestMethod]
        public void ClassicalGameLogicCreatesTheSameInstance()
        {
            var firstInstance = ClassicalGameLogic.Instance();
            var secondInstance = ClassicalGameLogic.Instance();
            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void IsWinnerMethodLogicWorks()
        {
            var emptyInput = new byte[0, 0];
            var upLeftInput = new byte[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var downRightInput = new byte[4, 4] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 },
            };

            var downLeftInput = new byte[4, 4] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 0, 0, 0 },
            };

            var upRightInput = new byte[4, 4] 
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var instance = ClassicalGameLogic.Instance();
            Assert.AreEqual(true, instance.IsWinner(emptyInput));
            Assert.AreEqual(false, instance.IsWinner(upLeftInput));
            Assert.AreEqual(false, instance.IsWinner(upRightInput));
            Assert.AreEqual(false, instance.IsWinner(downLeftInput));
            Assert.AreEqual(false, instance.IsWinner(downRightInput));
        }

        [TestMethod]
        public void FallDownLogicWorks()
        {
            const int size = 4;

            var inputMixed = new byte[size, size] 
            {
                { 1, 0, 1, 1 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 1, 0 },
            };

            var expectedInputMixed = new byte[size, size] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var inputDown = new byte[size, size] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
            };

            var expectedInputDown = new byte[size, size] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
            };

            var inputFull = new byte[size, size] 
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var expectedInputFull = new byte[size, size] 
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var inputEmpty = new byte[size, size] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var expectedInputEmpty = new byte[size, size] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var instance = ClassicalGameLogic.Instance();
            instance.FallDown(inputMixed);
            instance.FallDown(inputFull);
            instance.FallDown(inputEmpty);
            instance.FallDown(inputDown);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Assert.AreEqual(expectedInputMixed[row, col], inputMixed[row, col]);
                    Assert.AreEqual(expectedInputFull[row, col], inputFull[row, col]);
                    Assert.AreEqual(expectedInputEmpty[row, col], inputEmpty[row, col]);
                    Assert.AreEqual(expectedInputDown[row, col], inputDown[row, col]);
                }
            }
        }

        [TestMethod]
        public void ModifyGameFieldLogicWorksWithFullCell()
        {
            const int size = 8;

            var input = new byte[size, size] 
            {
                { 1, 2, 2, 2, 2, 2, 2, 1 },
                { 2, 1, 2, 2, 2, 2, 2, 1 },
                { 2, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 2, 1, 2, 2, 1, 2, 2 },
                { 2, 2, 2, 1, 2, 1, 2, 2 },
                { 1, 2, 2, 1, 1, 1, 2, 2 },
                { 2, 1, 1, 1, 2, 2, 1, 2 },
                { 1, 1, 2, 1, 1, 1, 2, 2 },
            };

            var expected = new byte[size, size] 
            {
                { 1, 2, 2, 2, 2, 2, 2, 0 },
                { 2, 0, 2, 2, 2, 2, 2, 0 },
                { 2, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 2, 0, 2, 2, 0, 2, 2 },
                { 2, 2, 2, 0, 2, 0, 2, 2 },
                { 1, 2, 2, 0, 0, 0, 2, 2 },
                { 2, 0, 0, 0, 2, 2, 1, 2 },
                { 0, 0, 2, 0, 0, 0, 2, 2 },
            };

            var instance = ClassicalGameLogic.Instance();
            var modified = instance.ModifyGameField(input, 1, 1);
            Assert.AreEqual(true, modified);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Assert.AreEqual(expected[row, col], input[row, col]);
                }
            }
        }

        [TestMethod]
        public void ModifyGameFieldLogicWorksWithEmptyCell()
        {
            const int size = 2;

            var input = new byte[size, size] 
            {
                { 0, 1},
                { 1, 1},
            };

            var expected = new byte[size, size] 
            {
                { 0, 1},
                { 1, 1},
            };

            var instance = ClassicalGameLogic.Instance();
            var modified = instance.ModifyGameField(input, 0, 0);
            Assert.AreEqual(false, modified);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Assert.AreEqual(expected[row, col], input[row, col]);
                }
            }
        }

        [TestMethod]
        public void ProcessInputRestartsGameFieldAndMoves()
        {
            int userMoves = 1;
            string restart = "RESTART";
            var field = new byte[4, 4] 
            {
                { 0, 1, 2, 3 },
                { 1, 1, 2, 3 },
                { 1, 1, 2, 3 },
                { 1, 1, 2, 3 },
            };
            GameField fieldUtility = ClassicalGameField.Instance();
            string[,] topFive = new string[0, 0];
            GameLogic gameEngine = ClassicalGameLogic.Instance();

            var expectedMoves = 0;

            gameEngine.ProcessUserInput(ref userMoves, ref restart, ref field, ref fieldUtility, ref topFive, ref gameEngine);
            Assert.AreEqual(expectedMoves, userMoves);
        }
    }
}