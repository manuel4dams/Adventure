using Framework.Collision.Calculation;
using Framework.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.Collision.Calculation
{
    [TestClass]
    public class RectangleRectangleUnrotatedCalculatorTests
    {
        // testcase 1: rectangleA does not intersect with rectangleB
        [TestMethod]
        public void IntersectsTest_NoIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 0f));
            var transformA = new Transform();
            transformA.position = new Vector2(5f, 5f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsFalse(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 3: rectangleA (left) intersects with rectangleB (right)
        [TestMethod]
        public void IntersectsTest_rightIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(1f, 0f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 2: rectangleA (right) intersects with rectangleB (left)
        [TestMethod]
        public void IntersectsTest_leftIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(-1f, 0f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 4: rectangleA (bottom) intersects with rectangleB (top)
        [TestMethod]
        public void IntersectsTest_bottomIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(0f, 1f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 5: rectangleA (Top) intersects with rectangleB (bottom)
        [TestMethod]
        public void IntersectsTest_topIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(0f, 1f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 6:
        // rectangleA (right) intersects with rectangleB (left) and
        // rectangleA (left) intersects with rectangleB (right) and
        // rectangleA (bottom) intersects with rectangleB (top) and
        // rectangleA (Top) intersects with rectangleB (bottom)
        [TestMethod]
        public void IntersectsTest_allIntersect()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = Vector2.Zero;


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(RectangleRectangleUnrotatedCalculator.Intersects(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 1: rectangleA (right) overlaps with rectangleB (left)
        [TestMethod]
        public void CalculateOverlapOffsetTest_rightOverlap()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(0.5f, 0f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(new Vector2(0.5f, 0f) == RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 2: rectangleA (left) overlaps with rectangleB (right)
        [TestMethod]
        public void CalculateOverlapOffsetTest_leftOverlap()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(-0.5f, 0f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(new Vector2(-0.5f, 0f) == RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 3: rectangleA (bottom) overlaps with rectangleB (top)
        [TestMethod]
        public void CalculateOverlapOffsetTest_bottomOverlap()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(0f, 0.5f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(new Vector2(0f, 0.5f) == RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 4: rectangleA (Top) overlaps with rectangleB (bottom)
        [TestMethod]
        public void CalculateOverlapOffsetTest_topOverlap()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = new Vector2(0f, -0.5f);


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            Assert.IsTrue(new Vector2(0f, -0.5f) == RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }

        // testcase 4: rectangleA (Top) overlaps with rectangleB (bottom)
        // testcase 5:
        // rectangleA (right) overlaps with rectangleB (left) and
        // rectangleA (left) overlaps with rectangleB (right) and
        // rectangleA (bottom) overlaps with rectangleB (top) and
        // rectangleA (Top) overlaps with rectangleB (bottom)
        [TestMethod]
        public void CalculateOverlapOffsetTest_allOverlap()
        {
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f));
            var transformA = new Transform();
            transformA.position = Vector2.Zero;


            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f));
            var transformB = new Transform();
            transformB.position = Vector2.Zero;

            var bla = RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB);

            Assert.IsTrue(new Vector2(1f, 0f) == RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                rectangleBoundsA,
                transformA,
                rectangleBoundsB,
                transformB));
        }
    }
}