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

            GameEngine.InitializeGame();

            GameEngine.PrintGameField();

            GameEngine.PlayGame();

            Console.WriteLine("Good Bye!");
        }
    }
}
