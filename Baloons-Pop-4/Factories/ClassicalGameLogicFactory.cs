// <copyright file="ClassicalGameLogicFactory.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame.Factories
{
    ////CREATIONAL DESIGN PATTERN : FACTORY METHOD
    using Utilities;

    /// <summary>
    /// The ClassicalGameLogicFactory class.
    /// </summary>
    public class ClassicalGameLogicFactory : GameLogicFactory
    {
        /// <summary>
        /// Returns an instance of the <see cref="ClassicalGameLogic"/> class.
        /// </summary>
        /// <returns>An instance of the <see cref="ClassicalGameLogic"/> class.</returns>
        public override GameLogic Create()
        {
            return ClassicalGameLogic.Instance();
        }
    }
}
