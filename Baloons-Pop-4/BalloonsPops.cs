// <copyright file="BalloonsPops.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame
{
    using System;
    using System.IO;
    using Utilities;
    
    /// <summary>
    /// The class containing the "Main" method of the program
    /// </summary>
    public class BalloonsPops
    {
        /// <summary>
        /// The main method of the program.
        /// </summary>
        public static void Main()
        {
            // TODO: DONE Check if the game logic is implemented as per GameRules.pdf
            // TODO: DONE Implement the local score board
            // TODO: Compile a project documentation
            // TODO: Follow the DRY and SOLID principles
            // TODO: DONE Check if the game is compliant with ALL requirements in the GameRules.pdf and Assignment.pdf
            // TODO: StyleCop the entire solution and fix the code accordingly
            GameEngine.InitializeGame();

            GameEngine.PrintGameField();

            GameEngine.PlayGame();

            GameEngine.ExitGame();
        }
    }
}
