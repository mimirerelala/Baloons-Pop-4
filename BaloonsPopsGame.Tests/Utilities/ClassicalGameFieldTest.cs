namespace BaloonsPopsGame.Tests.Utilities
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaloonsPopsGame.Utilities;
    using BaloonsPopsGame.Factories;

    [TestClass]
    public class ClassicalGameFieldTest
    {
        [TestMethod]
        public void InstanceMethodReturnsSameSingletonInstance()
        {
            var firstInstance = ClassicalGameField.Instance();
            var secondInstance = ClassicalGameField.Instance();
            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void GenerateDoesNotReturnNull()
        {
            var gameField = ClassicalGameField.Instance();
            var generatedInstance = gameField.Generate(0,0);
            Assert.IsNotNull(generatedInstance);
        }

        [TestMethod]
        public void GenerateFillsWithOneToFiveOnly()
        {
            byte acceptableMin = 1;
            byte acceptableMax = 4;
            byte rows = 50;
            byte cols = 50;
            var gameField = ClassicalGameField.Instance();
            var generatedInstance = gameField.Generate(rows, cols);
            foreach (var cell in generatedInstance)
            {
                Assert.IsTrue(cell >= acceptableMin && cell <= acceptableMax); 
            }
        }



    }
}
