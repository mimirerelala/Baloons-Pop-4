namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class GameEngine
    {
        public abstract void CheckCell(byte[,] gameField, int row, int col, int target);

        public abstract void ExecuteAllChecks(byte[,] gameField, int row, int col, byte target);

        public abstract bool ModifyGameField(byte[,] gameField, int row, int col);
    }
}
