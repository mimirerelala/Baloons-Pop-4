// <copyright file="GameLogicFactory.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
// <summary>The GameLogicFactory class</summary>
namespace BaloonsPopsGame.Factories
{
    ////BEHAVIORAL DESIGN PATTERN : TEMPLATE METHOD
    using Utilities;

    /// <summary>
    /// The abstract class GameLogicFactory.
    /// </summary>
    public abstract class GameLogicFactory
    {
        /// <summary>
        /// Returns an instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <returns>An instance of the <see cref="GameLogic"/> class.</returns>
        public abstract GameLogic Create();
    }
}