namespace BaloonsPopsGame.Factories
{
    using Utilities;
    class ClassicalGameLogicFactory : GameLogicsFactory
    {
        public override GameLogic Create()
        {
            return ClassicalGameLogic.Instance();
        }
    }
}
