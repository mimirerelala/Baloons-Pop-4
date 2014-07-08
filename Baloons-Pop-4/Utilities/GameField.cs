namespace BaloonsPopsGame.Utilities
{
    using System;
    using System.Linq;

    public abstract class GameField
    {
        public abstract byte[,] Generate(byte rows, byte cols);

        public abstract void Print(byte[,] field);
    }
}
