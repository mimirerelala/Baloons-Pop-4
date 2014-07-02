namespace BaloonsPopsGame.Utilities
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

        public abstract bool IsWinner(byte[,] gameField);

        public abstract void ProcessUserInput(ref int userMoves, ref string commandInput, ref byte[,] gameField, ref GameField gameFieldUtility, ref string[,] topFive, ref GameEngine gameEngine);
    }
}
