namespace BaloonsPopsGame.Tests
{
    using System;
    using BaloonsPopsGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassicalGameLogicFactoryTest
    {
        [TestMethod]
        public void ClassicalGameLogicFactoryCreatesSameInstance()
        {
            var gameLogicFactory = new Factories.ClassicalGameLogicFactory();
            var firstInstance = gameLogicFactory.Create();
            var secondInstance = gameLogicFactory.Create();
            Assert.AreSame(firstInstance, secondInstance);
        }
    }
}
