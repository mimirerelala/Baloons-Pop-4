namespace BaloonsPopsGame.Utilities
{
    //STRUCTURAL DESIGN PATTERN : FACADE
    using System;
    using System.Linq;
    using BaloonsPopsGame.Factories;

    public static class GameEngine
    {
        private static string[,] topFive;

        private static GameFieldsFactory gameFieldFactory;
        private static GameField gameFieldUtility;
        private static byte[,] gameField;

        private static GameLogicsFactory gameLogicFactory;
        private static GameLogic gameLogic;

        private static string currentCommand;
        private static int userMovesCount;

        public static void InitializeGame()
        {
            GameEngine.topFive = new string[5, 2];
            GameEngine.gameFieldFactory = new ClassicalGameFieldFactory();
            GameEngine.gameFieldUtility = gameFieldFactory.Create();
            
            GameEngine.gameLogicFactory = new ClassicalGameLogicFactory();
            GameEngine.gameLogic = gameLogicFactory.Create();
            
            GameEngine.gameField = gameFieldUtility.Generate(5, 10);

            GameEngine.currentCommand = null;
            GameEngine.userMovesCount = 0;
        }

        public static void PrintGameField() 
        {
            gameFieldUtility.Print(gameField);
        }

        public static void PlayGame() 
        {
            while (GameEngine.currentCommand != "EXIT")
            {
                Console.Write("Enter a cell (row and col): ");

                GameEngine.currentCommand = Console.ReadLine();
                GameEngine.currentCommand = currentCommand.ToUpper().Trim();

                GameEngine.gameLogic.ProcessUserInput(ref GameEngine.userMovesCount, ref GameEngine.currentCommand, ref GameEngine.gameField, ref GameEngine.gameFieldUtility, ref GameEngine.topFive, ref GameEngine.gameLogic);
            }
        }
    }
}
