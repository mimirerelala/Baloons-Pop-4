namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class BalloonsPops
    {
        private static byte[,] GenerateGameField(byte rows, byte cols)
        {
            var gameField = new byte[rows, cols];
            var generator = new Random();
            
            for (byte row = 0; row < rows; row++)
            {
                for (byte col = 0; col < cols; col++)
                {
                    var currentCellValue = (byte)generator.Next(1, 5);
                    gameField[row, col] = currentCellValue;
                }
            }
            
            return gameField;
        }

        private static void PrintGameField(byte[,] matrix)
        {
            var gameField = new StringBuilder();
            var fieldWidth = matrix.GetLength(1);
            var fieldHeight = matrix.GetLength(0);
            
            gameField.Append("    ");

            for (byte col = 0; col < fieldWidth; col++)
            {
                gameField.Append(col + " ");
            }

            gameField.AppendLine();
            gameField.Append("   ");
            gameField.Append('-', fieldWidth * 2 + 1);
            gameField.AppendLine();

            for (byte row = 0; row < fieldHeight; row++)
            {
                gameField.Append(row + " | ");

                for (byte col = 0; col < fieldWidth; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        gameField.Append("  ");
                    }
                    else
                    {
                        gameField.Append(matrix[row, col] + " ");
                    }
                }

                gameField.Append("| ");
                gameField.AppendLine();
            }

            gameField.Append("   ");
            gameField.Append('-', fieldWidth * 2 + 1);

            Console.WriteLine(gameField);
        }
        
        private static void CheckCell(byte[,] gameField, int row, int col, int target)
        {
            try
            {
                if (gameField[row, col] == target)
                {
                    gameField[row, col] = 0;
                    CheckCell(gameField, row, col, target);
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

        private static void ExecuteAllChecks(byte[,] gameField, int row, int col, byte target)
        {
            CheckCell(gameField, row + 1, col, target);
            CheckCell(gameField, row - 1, col, target);
            CheckCell(gameField, row, col + 1, target);
            CheckCell(gameField, row, col - 1, target);
        }
        
        static bool ModifyGameField(byte[,] gameField, int row, int col)
        {
            if (gameField[row, col] == 0)
            {
                return true;
            }

            byte searchedTarget = gameField[row, col];
            gameField[row, col] = 0;
            ExecuteAllChecks(gameField, row, col, searchedTarget);
            return false;
        }  
       

        static bool IsWinner(byte[,] gameField)
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
                for (int k = colLenght - 1; (k >= 0); k--)
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

        static void SortAndPrintChart(string[,] tableToSort)
        {
            List<Row> klasirane = new List<Row>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new Row(tableToSort[i, 1], int.Parse(tableToSort[i, 0])));
            }

            klasirane.Sort();
            Console.WriteLine("---------TOP FIVE chart-----------");
            for (int i = 0; i < klasirane.Count; ++i)
            {
                Row slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        static bool IsPlayerInChart(string[,] chart, int points)
        {
            bool skilled = false;
            int worstMoves = 0;
            int worstMoveschartPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string commandInputUserName = Console.ReadLine();
                    chart[i, 0] = points.ToString();
                    chart[i, 1] = commandInputUserName;
                    skilled = true;
                    break;
                }
            }
            if (skilled == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(chart[i, 0]) > worstMoves)
                    {
                        worstMoveschartPosition = i;
                        worstMoves = int.Parse(chart[i, 0]);
                    }
                }
            }
            if (points < worstMoves && skilled == false)
            {
                Console.WriteLine("Type in your name.");
                string commandInputUserName = Console.ReadLine();
                chart[worstMoveschartPosition, 0] = points.ToString();
                chart[worstMoveschartPosition, 1] = commandInputUserName;
                skilled = true;
            }
            return skilled;
        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] gameField = GenerateGameField(5, 10);

            PrintGameField(gameField);
            string commandInput = null;
            int userMoves = 0;
            while (commandInput != "EXIT")
            {
                Console.WriteLine("Enter a row and col: ");
                commandInput = Console.ReadLine();
                commandInput = commandInput.ToUpper().Trim();

                switch (commandInput)
                {
                    case "RESTART":
                        gameField = GenerateGameField(5, 10);
                        PrintGameField(gameField);
                        userMoves = 0;
                        break;
                    case "TOP":
                        SortAndPrintChart(topFive);
                        break;
                    default:
                        if ((commandInput.Length == 3) && (commandInput[0] >= '0' && commandInput[0] <= '9') && (commandInput[2] >= '0' && commandInput[2] <= '9') && (commandInput[1] == ' ' || commandInput[1] == '.' || commandInput[1] == ','))
                        {
                            int userRow, userCol;
                            userRow = int.Parse(commandInput[0].ToString());
                            if (userRow > 4)
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }

                            userCol = int.Parse(commandInput[2].ToString());
                            if (ModifyGameField(gameField, userRow, userCol))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }

                            userMoves++;
                            if (IsWinner(gameField))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (IsPlayerInChart(topFive, userMoves))
                                {
                                    SortAndPrintChart(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                gameField = GenerateGameField(5, 10);
                                userMoves = 0;
                            }

                            PrintGameField(gameField);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }
                }
            }
            Console.WriteLine("Good Bye! ");
        }
    }
}
