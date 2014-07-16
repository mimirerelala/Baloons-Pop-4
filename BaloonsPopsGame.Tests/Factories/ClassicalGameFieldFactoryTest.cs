namespace BaloonsPopsGame.Tests
{
    using System;
    using BaloonsPopsGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassicalGameFieldFactoryTest
    {
        [TestMethod]
        public void GameFieldFactoryCreatesTheSameInstance()
        {
            var gameFieldFactory = new Factories.ClassicalGameFieldFactory();
            var firstInstance = gameFieldFactory.Create();
            var secondInstance = gameFieldFactory.Create();
            Assert.AreSame(firstInstance, secondInstance);
        }
    }
}
