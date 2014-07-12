namespace BaloonsPopsGame.Utilities
{
    ////CREATIONAL DESIGN PATTERN : SINGLETON
    using System;
    using Factories;

    /// <summary>
    /// The ClassicalGameField class
    /// </summary>
    public class ClassicalGameField : GameField
    {
        /// <summary>
        /// The only instance of the <see cref="ClassicalGameField"/> class
        /// </summary>
        private static ClassicalGameField instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassicalGameField"/> class.
        /// </summary>
        protected ClassicalGameField() 
        {
        }

        /// <summary>
        /// Static method for implementing "Singleton"design pattern
        /// </summary>
        /// <returns>Only instance of the <see cref="ClassicalGameField"/> class</returns>
        public static ClassicalGameField Instance()
        {
            if (instance == null)
            {
                instance = new ClassicalGameField();
            }

            return instance;
        }

        /// <summary>
        /// Generates game field represented by a two dimensional array.
        /// </summary>
        /// <param name="rows">Number of rows in the array</param>
        /// <param name="cols">Number of columns in the array</param>
        /// <returns>Returns an array, filled with random numbers </returns>
        public override byte[,] Generate(byte rows, byte cols) 
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

        /// <summary>
        /// Prints the field on the console.
        /// </summary>
        /// <param name="field">An array representing the game field</param>
        public override void Print(byte[,] field)
        {
            Console.Clear();

            var fieldWidth = field.GetLength(1);
            var fieldHeight = field.GetLength(0);
            var horizontalBoreder = new String('-', (fieldWidth * 3) + 1);

            Console.Write("    ");

            for (byte col = 0; col < fieldWidth; col++)
            {
                Console.Write(" " + col + " ");
            }

            Console.WriteLine();
            Console.Write("   ");
            Console.Write(horizontalBoreder);
            Console.WriteLine();

            for (byte row = 0; row < fieldHeight; row++)
            {
                Console.Write(row + " | ");

                for (byte col = 0; col < fieldWidth; col++)
                {
                    if (field[row, col] == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        GameFieldCellsFlyweightFactory.GetCellByValue(field[row, col]).Draw();
                    }
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");
            Console.Write(horizontalBoreder);

            Console.WriteLine();
        }            
    }
}
