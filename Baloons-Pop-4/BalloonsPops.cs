namespace BaloonsPopsGame
{
    using System;
    using Utilities;
    
    public class BalloonsPops
    {
        public static void Main(string[] args)
        {
            ////TODO: Check if the game logic is implemented as per GameRules.pdf
            ////TODO: Implement the local score board WITH MEMENTO pattern
            ////TODO: Compile a project documentation
            ////TODO: Follow the DRY and SOLID principles
            ////TODO: Implement Unit Tests
            ////TODO: Check if the game is compliant with ALL requirements in the GameRules.pdf and Assignment.pdf
            ////TODO: StyleCop the entire solution and fix the code accordingly

            GameEngine.InitializeGame();

            GameEngine.PrintGameField();

            GameEngine.PlayGame();

            GameEngine.ExitGame();
        }
    }
}
