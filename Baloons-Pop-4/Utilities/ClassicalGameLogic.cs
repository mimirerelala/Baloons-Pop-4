namespace BaloonsPopsGame.Utilities
{
    ////CREATIONAL DESIGN PATTERN : SINGLETON
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassicalGameLogic : GameLogic
    {
        private static ClassicalGameLogic instance;

        protected ClassicalGameLogic() 
        {
        }

        public static ClassicalGameLogic Instance()
        {
            if (instance == null)
            {
                instance = new ClassicalGameLogic();
            }

            return instance;
        }

        public override void CheckCell(byte[,] gameField, int row, int col, int target)
        {
            try
            {
                if (gameField[row, col] == target)
                {
                    gameField[row, col] = 0;
                    this.CheckCell(gameField, row, col, target);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine("The cell you are trying to check is out of the gamefield!");
            }
        }

        public override void ExecuteAllChecks(byte[,] gameField, int row, int col, byte target)
        {
            this.CheckCell(gameField, row + 1, col, target);
            this.CheckCell(gameField, row - 1, col, target);
            this.CheckCell(gameField, row, col + 1, target);
            this.CheckCell(gameField, row, col - 1, target);
        }

        public override bool ModifyGameField(byte[,] gameField, int row, int col)
        {
            if (gameField[row, col] == 0)
            {
                return true;
            }

            byte searchedTarget = gameField[row, col];
            gameField[row, col] = 0;
            this.ExecuteAllChecks(gameField, row, col, searchedTarget);
            return false;
        }

        public override bool IsWinner(byte[,] gameField)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int colLenght = gameField.GetLength(0);
            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                for (int i = 0; i < colLenght; i++)
                {
                    if (gameField[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(gameField[i, j]);
                    }
                }

                for (int k = colLenght - 1; k >= 0; k--)
                {
                    try
                    {
                        gameField[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        gameField[k, j] = 0;
                    }
                }
            }

            return isWinner;
        }

        public override void ProcessUserInput(ref int userMoves, ref string commandInput, ref byte[,] gameField, ref GameField gameFieldUtility, ref string[,] topFive, ref GameLogic gameEngine)
        {
            switch (commandInput)
            {
                case "RESTART":
                    gameField = gameFieldUtility.Generate(5, 10);
                    gameFieldUtility.Print(gameField);
                    userMoves = 0;
                    break;
                case "TOP":
                    HighScores.SortAndPrint(topFive);
                    break;
                case "EXIT":
                    break;
                default:
                    ////TODO: Remove the magic numbers '0' and '9' with gameField width and height
                    if ((commandInput.Length == 3) && (commandInput[0] >= '0' && commandInput[0] <= '9') && (commandInput[2] >= '0' 
                        && commandInput[2] <= '9') && (commandInput[1] == ' ' || commandInput[1] == '.' || commandInput[1] == ','))
                    {
                        int userRow, userCol;
                        userRow = int.Parse(commandInput[0].ToString());
                        if (userRow > 4)
                        {
                            Console.WriteLine("Wrong input! Please try again!");
                            return;
                        }

                        userCol = int.Parse(commandInput[2].ToString());
                        if (gameEngine.ModifyGameField(gameField, userRow, userCol))
                        {
                            Console.WriteLine("Cannot pop a missing ballon!");
                            return;
                        }

                        userMoves++;
                        if (gameEngine.IsWinner(gameField))
                        {
                            Console.WriteLine("Congratulations ! You have completed the game in {0} moves!", userMoves);
                            if (HighScores.IsPlayerInChart(topFive, userMoves))
                            {
                                HighScores.SortAndPrint(topFive);
                            }
                            else
                            {
                                Console.WriteLine("I am sorry, but you are not skillful enough for the TopFive chart!");
                            }

                            gameField = gameFieldUtility.Generate(5, 10);
                            userMoves = 0;
                        }

                        gameFieldUtility.Print(gameField);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Please try again!");
                        break;
                    }
            }
        }
    }
}
