namespace BaloonsPopsGame.Tests
{
    using System;
    using BaloonsPopsGame.Factories;
    using BaloonsPopsGame.Tests.Utilities;
    using BaloonsPopsGame.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var upperLeftInput = new byte[4, 4]
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

            var upperRightInput = new byte[4, 4] 
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var instance = ClassicalGameLogic.Instance();
            Assert.AreEqual(true, instance.IsWinner(emptyInput));
            Assert.AreEqual(false, instance.IsWinner(upperLeftInput));
            Assert.AreEqual(false, instance.IsWinner(upperRightInput));
            Assert.AreEqual(false, instance.IsWinner(downLeftInput));
            Assert.AreEqual(false, instance.IsWinner(downRightInput));
        }

        [TestMethod]
        public void FallDownLogicWorks()
        {
            const int SIZE = 4;

            var inputMixed = new byte[SIZE, SIZE] 
            {
                { 1, 0, 1, 1 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 1, 0 },
            };

            var expectedInputMixed = new byte[SIZE, SIZE] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var inputDown = new byte[SIZE, SIZE] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
            };

            var expectedInputDown = new byte[SIZE, SIZE] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
            };

            var inputFull = new byte[SIZE, SIZE] 
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var expectedInputFull = new byte[SIZE, SIZE] 
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
            };

            var inputEmpty = new byte[SIZE, SIZE] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var expectedInputEmpty = new byte[SIZE, SIZE] 
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

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
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
            const int SIZE = 8;

            var input = new byte[SIZE, SIZE] 
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

            var expected = new byte[SIZE, SIZE] 
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
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    Assert.AreEqual(expected[row, col], input[row, col]);
                }
            }
        }

        [TestMethod]
        public void ModifyGameFieldLogicWorksWithEmptyCell()
        {
            const int SIZE = 2;

            var input = new byte[SIZE, SIZE] 
            {
                { 0, 1 },
                { 1, 1 },
            };

            var expected = new byte[SIZE, SIZE] 
            {
                { 0, 1 },
                { 1, 1 },
            };

            var instance = ClassicalGameLogic.Instance();
            var modified = instance.ModifyGameField(input, 0, 0);
            Assert.AreEqual(false, modified);
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    Assert.AreEqual(expected[row, col], input[row, col]);
                }
            }
        }

        [TestMethod]
        public void ProcessInputRestartsMoves()
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

        [TestMethod]
        public void ProcessInputCommandIsChecked()
        {
            int userMoves = 0;
            string firstCommand = "invalidCommand";
            string secondCommand = string.Empty;
            string thirdCommand = "-1 0";
            string fourthCommand = "0 1";
            string fifthCommand = "0 0";

            var field = new byte[0, 0];
            GameField fieldUtility = ClassicalGameField.Instance();
            string[,] topFive = new string[0, 0];
            GameLogic gameEngine = ClassicalGameLogic.Instance();

            var еxpected = "Wrong input! Please try again!" + Environment.NewLine;
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                gameEngine.ProcessUserInput(ref userMoves, ref firstCommand, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());

                consoleOutput.ResetOutput();
                gameEngine.ProcessUserInput(ref userMoves, ref secondCommand, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());

                consoleOutput.ResetOutput();
                gameEngine.ProcessUserInput(ref userMoves, ref thirdCommand, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());

                consoleOutput.ResetOutput();
                gameEngine.ProcessUserInput(ref userMoves, ref fourthCommand, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());

                consoleOutput.ResetOutput();
                gameEngine.ProcessUserInput(ref userMoves, ref fifthCommand, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PopMissingBaloonShowsCorrectMessage()
        {
            int userMoves = 0;
            string command = "0 0";

            var field = new byte[1, 1];
            GameField fieldUtility = ClassicalGameField.Instance();
            string[,] topFive = new string[0, 0];
            GameLogic gameEngine = ClassicalGameLogic.Instance();

            var еxpected = "Cannot pop a missing ballon!" + Environment.NewLine;
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                gameEngine.ProcessUserInput(ref userMoves, ref command, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(еxpected, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void ProcessUserInputResetsMovesOnWin()
        {
            int userMoves = 1;
            string command = "0 0";
            string[,] topFive = new string[5, 5];
            GameField fieldUtility = ClassicalGameField.Instance();
            GameLogic gameEngine = ClassicalGameLogic.Instance();
            var field = new byte[2, 2] 
            { 
                { 1, 1 },
                { 1, 0 },
            };

            var input = new ConsoleInput("testName");
            var currentConsoleIn = Console.OpenStandardInput();
            using (input)
            {
                gameEngine.ProcessUserInput(ref userMoves, ref command, ref field, ref fieldUtility, ref topFive, ref gameEngine);
                Assert.AreEqual(0, userMoves);
            }
        }
    }
}