namespace BaloonsPopsGame.Utilities
{
    using System;

    public class GameFieldCell
    {
        private readonly int value;
        private readonly ConsoleColor foregroundColor;
        private readonly ConsoleColor backgroundColor;

        public GameFieldCell(int value, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.value = value;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
        }

        public void Draw()
        {
            Console.ForegroundColor = this.foregroundColor;
            Console.BackgroundColor = this.backgroundColor;

            Console.Write(" " + this.value + " ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
