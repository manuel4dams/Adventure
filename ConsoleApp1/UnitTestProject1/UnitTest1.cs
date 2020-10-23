using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestProject1
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CalcTest
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
