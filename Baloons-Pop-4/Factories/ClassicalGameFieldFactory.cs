// <copyright file="ClassicalGameFieldFactory.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Factories
{
    ////CREATIONAL DESIGN PATTERN : FACTORY METHOD
    using Utilities;

    /// <summary>
    /// The ClassicalGameFieldFactory class.
    /// </summary>
    public class ClassicalGameFieldFactory : GameFieldFactory
    {
        /// <summary>
        /// Creates new game field.
        /// </summary>
        /// <returns>An instance of <see cref="ClassicalGameFieldFactory"/> class.</returns>
        public override GameField Create()
        {
            return ClassicalGameField.Instance();
        }
    }
}