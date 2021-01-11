using System.Diagnostics.CodeAnalysis;
using Framework.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.UtilTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LerpUtilsTests
    {
        // testcase2: provide a, b, percentage 0%
        [TestMethod]
        public void LerpTest_ZeroPercent()
        {
            const float testFloatA = 1f;
            const float testFloatB = 2f;

            Assert.IsTrue(LerpUtils.Lerp(testFloatA, testFloatB, 0) == 1f);
        }

        // testcase2: provide a, b, percentage 100%
        [TestMethod]
        public void LerpTest_HundredPercent()
        {
            const float testFloatA = 1f;
            const float testFloatB = 2f;

            Assert.IsTrue(LerpUtils.Lerp(testFloatA, testFloatB, 100) == 101f);
        }

        [TestMethod]
        public void SmoothnessToLerpTest()
        {
            const float testFloat = 1f;

            Assert.IsTrue(LerpUtils.SmoothnessToLerp(testFloat) == 0.5f);
        }
    }
}