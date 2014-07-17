namespace BaloonsPopsGame.Tests
{
    using BaloonsPopsGame.Factories;
    using BaloonsPopsGame.Utilities;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassicalGameLogicTest
    {
        [TestMethod]
        public void ClassicalGameLogicCreatesTheSameInstance()
        {
            var firstInstance = ClassicalGameLogic.Instance();
            var secondInstance = ClassicalGameLogic.Instance();
            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void IsWinnerWorks()
        {
            var emptyInput = new byte[0, 0];
            var upLeftInput = new byte[4, 4] 
            {
                { 1, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var downRightInput = new byte[4, 4] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 },
            };

            var downLeftInput = new byte[4, 4] 
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 0, 0, 0 },
            };

            var upRightInput = new byte[4, 4] 
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
            };

            var instance = ClassicalGameLogic.Instance();
            Assert.AreEqual(true, instance.IsWinner(emptyInput));
            Assert.AreEqual(false, instance.IsWinner(upLeftInput));
            Assert.AreEqual(false, instance.IsWinner(upRightInput));
            Assert.AreEqual(false, instance.IsWinner(downLeftInput));
            Assert.AreEqual(false, instance.IsWinner(downRightInput));
        }












    }
}
