namespace BaloonsPopsGame.Factories
{
    ////CREATIONAL DESIGN PATTERN : FACTORY METHOD
    using Utilities;

    public class ClassicalGameFieldFactory : GameFieldFactory
    {
        public override GameField Create()
        {
            return ClassicalGameField.Instance();
        }
    }
}