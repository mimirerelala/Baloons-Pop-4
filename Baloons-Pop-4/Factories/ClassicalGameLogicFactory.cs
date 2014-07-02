namespace BaloonsPopsGame.Factories
{
    //CREATIONAL DESIGN PATTERN : FACTORY METHOD
    using Utilities;
    class ClassicalGameLogicFactory : GameLogicFactory
    {
        public override GameLogic Create()
        {
            return ClassicalGameLogic.Instance();
        }
    }
}
