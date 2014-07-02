namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    abstract class GameField
    {
        public abstract byte[,] Generate(byte rows, byte cols);
        public abstract void Print(byte[,] field);
        
    }
}
