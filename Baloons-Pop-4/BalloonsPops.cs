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
            //TODO: Check if the game logic is implemented as per GameRules.pdf
            //TODO: Implement 2 structural and two behavioral design patters
            //TODO: Implement colors for the numbers in the console
            //TODO: Implement the local score board
            //TODO: Compile a project documentation
            //TODO: Follow the DRY and SOLID principles
            //TODO: Implement Unit Tests
            //TODO: Check if the game is compliant with ALL requirements in the GameRules.pdf and Assignment.pdf

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
                Console.Write("Enter a cell (row and col): ");

                commandInput = Console.ReadLine();
                commandInput = commandInput.ToUpper().Trim();

                gameEngine.ProcessUserInput(ref userMoves, ref commandInput, ref gameField, ref gameFieldUtility, ref topFive, ref gameEngine);
            }

            Console.WriteLine("Good Bye!");
        }
    }
}
