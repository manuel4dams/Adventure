using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForrestAdventure;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestForrestAdventure
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void DistanceTest()
        {
            Program c = new Program();
            int result = c.Distance(7, 5);
            Assert.AreEqual(2, result);
        }
    }
}