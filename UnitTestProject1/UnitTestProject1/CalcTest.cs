using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolesSpiel;
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
            Calc c = new Calc();
            int result = c.Distance(7, 5);
            Assert.AreEqual(2, result);
        }
    }
}
