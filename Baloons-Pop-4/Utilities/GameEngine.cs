// <copyright file="GameEngine.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Utilities
{
    ////STRUCTURAL DESIGN PATTERN : FACADE
    using System;
    using System.Linq;
    using BaloonsPopsGame.Factories;

    /// <summary>
    /// The GameEngine class.
    /// </summary>
    public static class GameEngine
    {
        /// <summary>
        /// Two dimensional array containing the name and the score of the top five players.
        /// </summary>
        private const string TOP_FIVE_FILE_PATH = @"../../files/chart.txt";

        /// <summary>
        /// The top five players.
        /// </summary>
        private static string[,] topFive;

        /// <summary>
        /// Instance of the <see cref="GameFieldFactory"/> class.
        /// </summary>
        private static GameFieldFactory gameFieldFactory;

        /// <summary>
        /// Instance of the <see cref="GameField"/> class.
        /// </summary>
        private static GameField gameFieldUtility;

        /// <summary>
        /// Two dimensional array representing the game field.
        /// </summary>
        private static byte[,] gameField;

        /// <summary>
        /// Instance of the <see cref="GameLogicFactory"/> class.
        /// </summary>
        private static GameLogicFactory gameLogicFactory;

        /// <summary>
        /// Instance of the <see cref="GameLogic"/> class.
        /// </summary>
        private static GameLogic gameLogic;

        /// <summary>
        /// The user command.
        /// </summary>
        private static string currentCommand;

        /// <summary>
        /// Count of the users moves so far.
        /// </summary>
        private static int userMovesCount;

        /// <summary>
        /// Initializes all fields.
        /// </summary>
        public static void InitializeGame()
        {
            GameEngine.topFive = HighScores.Load(GameEngine.TOP_FIVE_FILE_PATH);
            GameEngine.gameFieldFactory = new ClassicalGameFieldFactory();
            GameEngine.gameFieldUtility = gameFieldFactory.Create();
            
            GameEngine.gameLogicFactory = new ClassicalGameLogicFactory();
            GameEngine.gameLogic = gameLogicFactory.Create();
            
            GameEngine.gameField = gameFieldUtility.Generate(5, 10);

            GameEngine.currentCommand = null;
            GameEngine.userMovesCount = 0;
        }

        /// <summary>
        /// Visualizes the game field.
        /// </summary>
        public static void PrintGameField() 
        {
            gameFieldUtility.Print(gameField);
        }

        /// <summary>
        /// Starts the game and executes the game logic.
        /// </summary>
        public static void PlayGame() 
        {
            while (GameEngine.currentCommand != "EXIT")
            {
                Console.Write("Enter a cell (row and col): ");
                GameEngine.currentCommand = Console.ReadLine();
                GameEngine.currentCommand = GameEngine.currentCommand.ToUpper().Trim();
                GameEngine.gameLogic.ProcessUserInput(ref GameEngine.userMovesCount, ref GameEngine.currentCommand, ref GameEngine.gameField, ref GameEngine.gameFieldUtility, ref GameEngine.topFive, ref GameEngine.gameLogic);
            }
        }

        /// <summary>
        /// Stops the game and prints the good bye message.
        /// </summary>
        internal static void ExitGame()
        {
            Console.WriteLine("Good-bye");
            HighScores.Save(GameEngine.topFive, GameEngine.TOP_FIVE_FILE_PATH);
        }
    }
}
