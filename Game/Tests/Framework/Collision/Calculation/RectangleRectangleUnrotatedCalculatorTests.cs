using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.Collision.Calculation
{
    [TestClass]
    public class RectangleRectangleUnrotatedCalculatorTests
    {
        // TODO implement test
        [TestMethod]
        public void IntersectsTest_NoIntersect()
        {
            // testcase 1: rectangleA does not intersect with rectangleB

            // testcase 2: rectangleA (right) intersects with rectangleB (left)

            // testcase 3: rectangleA (left) intersects with rectangleB (right)

            // testcase 4: rectangleA (bottom) intersects with rectangleB (top)

            // testcase 5: rectangleA (Top) intersects with rectangleB (bottom)

            // testcase 6:
            // rectangleA (right) intersects with rectangleB (left) and
            // rectangleA (left) intersects with rectangleB (right) and
            // rectangleA (bottom) intersects with rectangleB (top) and
            // rectangleA (Top) intersects with rectangleB (bottom)
        }

        // TODO implement test
        [Ignore]
        [TestMethod]
        public void CalculateOverlapOffsetTest()
        {
            Assert.Fail();
        }
    }
}