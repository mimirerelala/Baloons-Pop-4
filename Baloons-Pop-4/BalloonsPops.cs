namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class BalloonsPops
    {
        private static byte[,] GenerateMatrix(byte rows, byte cols)
        {
            var matrix = new byte[rows, cols];
            var generator = new Random();
            
            for (byte row = 0; row < rows; row++)
            {
                for (byte col = 0; col < cols; col++)
                {
                    var currentCellValue = (byte)generator.Next(1, 5);
                    matrix[row, col] = currentCellValue;
                }
            }
            
            return matrix;
        }

        private static void PrintMatrix(byte[,] matrix)
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

        static void CheckLeft(byte[,] matrix, int row, int col, int searchedItem)
        {
            int newRow = row;
            int newcol = col - 1;
            try
            {
                if (matrix[newRow, newcol] == searchedItem)
                {
                    matrix[newRow, newcol] = 0;
                    CheckLeft(matrix, newRow, newcol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckRight(byte[,] matrix, int row, int col, int searchedItem)
        {
            int newRow = row;
            int newcol = col + 1;
            try
            {
                if (matrix[newRow, newcol] == searchedItem)
                {
                    matrix[newRow, newcol] = 0;
                    CheckRight(matrix, newRow, newcol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckUp(byte[,] matrix, int row, int col, int searchedItem)
        {
            int newRow = row + 1;
            int newcol = col;
            try
            {
                if (matrix[newRow, newcol] == searchedItem)
                {
                    matrix[newRow, newcol] = 0;
                    CheckUp(matrix, newRow, newcol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckDown(byte[,] matrix, int row, int col, int searchedItem)
        {
            int newRow = row - 1;
            int newcol = col;
            try
            {
                if (matrix[newRow, newcol] == searchedItem)
                {
                    matrix[newRow, newcol] = 0;
                    CheckDown(matrix, newRow, newcol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static bool ModifyMatrix(byte[,] matrixToModify, int row, int col)
        {
            if (matrixToModify[row, col] == 0)
            {
                return true;
            }

            byte searchedTarget = matrixToModify[row, col];
            matrixToModify[row, col] = 0;
            ExecuteAllChecks(matrixToModify, row, col, searchedTarget);
            return false;
        }
  
        private static void ExecuteAllChecks(byte[,] matrixToModify, int row, int col, byte searchedTarget)
        {
            CheckLeft(matrixToModify, row, col, searchedTarget);
            CheckRight(matrixToModify, row, col, searchedTarget);
            CheckUp(matrixToModify, row, col, searchedTarget);
            CheckDown(matrixToModify, row, col, searchedTarget);
        }

        static bool IsWinner(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int colLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < colLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }
                for (int k = colLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
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

                klasirane.Add(new Row(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));
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
            byte[,] matrix = GenerateMatrix(5, 10);

            PrintMatrix(matrix);
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
                        matrix = GenerateMatrix(5, 10);
                        PrintMatrix(matrix);
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
                            if (ModifyMatrix(matrix, userRow, userCol))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }

                            userMoves++;
                            if (IsWinner(matrix))
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
                                matrix = GenerateMatrix(5, 10);
                                userMoves = 0;
                            }

                            PrintMatrix(matrix);
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
