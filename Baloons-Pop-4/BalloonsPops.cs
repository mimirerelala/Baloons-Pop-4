// <copyright file="BalloonsPops.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame
{
    using System;
    using Utilities;
    using System.IO;
    
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
            ////TODO: Check if the game logic is implemented as per GameRules.pdf
            ////TODO: Implement the local score board WITH MEMENTO pattern
            ////TODO: Compile a project documentation
            ////TODO: Follow the DRY and SOLID principles
            ////TODO: Check if the game is compliant with ALL requirements in the GameRules.pdf and Assignment.pdf
            ////TODO: StyleCop the entire solution and fix the code accordingly

            //GameEngine.InitializeGame();

            //GameEngine.PrintGameField();

            //GameEngine.PlayGame();

            //GameEngine.ExitGame();



            var board = new byte[3,3];

            ClassicalGameField field = ClassicalGameField.Instance();
            field.Print(board);

            //string expected = "     0  1  2  3 \n   -------------\n0 |  1  2  3  4 | \n1 |  1  1  1  1 | \n2 |  4  4  4  4 | \n   -------------";

            //Console.WriteLine("RRRRRRRRRRRRRRRRRRRRR");
            //Console.WriteLine(expected);










        }
    }
}
