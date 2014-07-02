namespace BaloonsPopsGame.Factories
{
    using Utilities;
    public class ClassicalGameFieldFactory : GameFieldsFactory
    {
        public override GameField Create()
        {
            return ClassicalGameField.Instance();
        }
    }
}

