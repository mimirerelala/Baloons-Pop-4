// <copyright file="GameFieldFactory.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
// <summary>The GameFieldFactory class</summary>
namespace BaloonsPopsGame.Factories
{
    ////BEHAVIORAL DESIGN PATTERN : TEMPLATE METHOD
    using Utilities;

    /// <summary>
    /// The abstract class GameFieldFactory.
    /// </summary>
    public abstract class GameFieldFactory
    {
        /// <summary>
        /// Returns an instance of the <see cref="GameField"/> class.
        /// </summary>
        /// <returns>An instance of the <see cref="GameField"/> class.</returns>
        public abstract GameField Create();
    }
}
