using System.Diagnostics.CodeAnalysis;
using Framework.Collision;
using Framework.Collision.Collider;
using Framework.Game;
using Framework.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.CollisionTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CollisionCalculatorTests
    {
        // case 1: first collider is rectangle, second is rectangle
        [TestMethod]
        public void UnrotatedIntersectsTest_Interect()
        {
            var gameObjectA = new GameObject();
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var colliderA = new RectangleColliderComponent(gameObjectA, rectangleBoundsA);

            var gameObjectB = new GameObject();
            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 2f), new Vector2(1f, 1f));
            var colliderB = new RectangleColliderComponent(gameObjectB, rectangleBoundsB);

            Assert.IsTrue(CollisionCalculator.UnrotatedIntersects(colliderA, colliderB));
        }

        // case 1: first collider is rectangle, second is rectangle
        [TestMethod]
        public void UnrotatedIntersectsTest_NoIntersect()
        {
            var gameObjectA = new GameObject();
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var colliderA = new RectangleColliderComponent(gameObjectA, rectangleBoundsA);

            var gameObjectB = new GameObject();
            var rectangleBoundsB = new RectangleBounds(new Vector2(5f, 5f), new Vector2(1f, 1f));
            var colliderB = new RectangleColliderComponent(gameObjectB, rectangleBoundsB);

            Assert.IsTrue(!CollisionCalculator.UnrotatedIntersects(colliderA, colliderB));
        }

        // case 1: first collider is rectangle, second is rectangle
        [TestMethod]
        public void UnrotatedOverlapTest_Overlapping()
        {
            var gameObjectA = new GameObject();
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var colliderA = new RectangleColliderComponent(gameObjectA, rectangleBoundsA);

            var gameObjectB = new GameObject();
            var rectangleBoundsB = new RectangleBounds(new Vector2(5f, 5f), new Vector2(1f, 1f));
            var colliderB = new RectangleColliderComponent(gameObjectB, rectangleBoundsB);

            Assert.IsTrue(new Vector2(3f, 0f) == CollisionCalculator.UnrotatedOverlap(colliderA, colliderB));
        }
    }
}