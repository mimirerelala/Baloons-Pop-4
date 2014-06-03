namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;

    class BalloonsPops
    {
        static byte[,] GenerateMatrix(byte rows, byte cols)
        {
            byte[,] temp = new byte[rows, cols];
            Random randNumber = new Random();
            for (byte row = 0; row < rows; row++)
            {
                for (byte col = 0; col < cols; col++)
                {
                    byte tempByte = (byte)randNumber.Next(1, 5);
                    temp[row, col] = tempByte;
                }
            }
            return temp;
        }

        static void PrintMatrix(byte[,] matrix)
        {
            Console.Write("    ");
            for (byte col = 0; col < matrix.GetLongLength(1); col++)
            {
                Console.Write(col + " ");
            }

            Console.Write("\n   ");
            for (byte col = 0; col < matrix.GetLongLength(1) * 2 + 1; col++)
            {
                Console.Write("-");
            }

            Console.WriteLine();         // trinket stuff for PrintMatrix() till here
            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");     //some trinket stuff again
            for (byte col = 0; col < matrix.GetLongLength(1) * 2 + 1; col++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
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
                    return;
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
                    return;
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
                    return;
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
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static bool ModifyMatrix(byte[,] matrixToModify, int rowAtm, int colAtm)
        {
            if (matrixToModify[rowAtm, colAtm] == 0)
            {
                return true;
            }
            byte searchedTarget = matrixToModify[rowAtm, colAtm];
            matrixToModify[rowAtm, colAtm] = 0;
            CheckLeft(matrixToModify, rowAtm, colAtm, searchedTarget);
            CheckRight(matrixToModify, rowAtm, colAtm, searchedTarget);
            CheckUp(matrixToModify, rowAtm, colAtm, searchedTarget);
            CheckDown(matrixToModify, rowAtm, colAtm, searchedTarget);
            return false;
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

        static bool IsPlayerInchart(string[,] chart, int points)
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
                            int userRow, usercol;
                            userRow = int.Parse(commandInput[0].ToString());
                            if (userRow > 4)
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }

                            usercol = int.Parse(commandInput[2].ToString());
                            if (ModifyMatrix(matrix, userRow, usercol))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }

                            userMoves++;
                            if (IsWinner(matrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (IsPlayerInchart(topFive, userMoves))
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