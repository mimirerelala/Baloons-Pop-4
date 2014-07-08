namespace BaloonsPopsGame.Utilities
{
    ////CREATIONAL DESIGN PATTERN : SINGLETON
    using System;
    using Factories;

    public class ClassicalGameField : GameField
    {
        private static ClassicalGameField instance;

        protected ClassicalGameField() 
        {
        }

        public static ClassicalGameField Instance()
        {
            if (instance == null)
            {
                instance = new ClassicalGameField();
            }

            return instance;
        }

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
