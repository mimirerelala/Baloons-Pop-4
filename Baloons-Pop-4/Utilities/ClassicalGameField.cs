namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClassicalGameField : GameField
    {
        private static ClassicalGameField instance;

        protected ClassicalGameField() { }

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
            var gameField = new StringBuilder();
            var fieldWidth = field.GetLength(1);
            var fieldHeight = field.GetLength(0);

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
                    if (field[row, col] == 0)
                    {
                        gameField.Append("  ");
                    }
                    else
                    {
                        gameField.Append(field[row, col] + " ");
                    }
                }

                gameField.Append("| ");
                gameField.AppendLine();
            }

            gameField.Append("   ");
            gameField.Append('-', fieldWidth * 2 + 1);

            Console.WriteLine(gameField);
        }            
    }
}
