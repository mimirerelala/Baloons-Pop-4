namespace BaloonsPopsGame.Factories
{
    using Utilities;
    class ClassicalGameEngineFactory : GameEnginesFactory
    {
        public override GameEngine Create()
        {
            return ClassicalGameEngine.Instance();
        }
    }
}
