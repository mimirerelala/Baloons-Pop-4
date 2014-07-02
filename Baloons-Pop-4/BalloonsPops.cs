namespace BaloonsPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities;
    using Factories;
    
    public class BalloonsPops
    {


        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            GameFieldsFactory gameFieldFactory = new ClassicalGameFieldFactory();
            GameField gameFieldUtility = gameFieldFactory.Create();

            GameEnginesFactory gameEngineFactory = new ClassicalGameEngineFactory();
            GameEngine gameEngine = gameEngineFactory.Create();

            byte[,] gameField = gameFieldUtility.Generate(5, 10);

            gameFieldUtility.Print(gameField);

            string commandInput = null;
            int userMoves = 0;

            while (commandInput != "EXIT")
            {
                Console.WriteLine("Enter a cell (row and col): ");

                commandInput = Console.ReadLine();
                commandInput = commandInput.ToUpper().Trim();

                gameEngine.ProcessUserInput(ref userMoves, ref commandInput, ref gameField, ref gameFieldUtility, ref topFive, ref gameEngine);
            }

            Console.WriteLine("Good Bye!");
        }
    }
}
