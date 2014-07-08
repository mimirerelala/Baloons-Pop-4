namespace BaloonsPopsGame.Factories
{
    ////BEHAVIORAL DESIGN PATTERN : TEMPLATE METHOD
    using Utilities;

    public abstract class GameFieldFactory
    {
        public abstract GameField Create();
    }
}
