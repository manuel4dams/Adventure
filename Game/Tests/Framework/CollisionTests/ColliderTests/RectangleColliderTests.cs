using System.Diagnostics.CodeAnalysis;
using Framework.Collision.Collider;
using Framework.Game;
using Framework.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.CollisionTests.ColliderTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RectangleColliderTests
    {
        [TestMethod]
        public void RectangleColliderTest()
        {
            var gameObject = new GameObject();
            var rectangleBounds = new RectangleBounds(new Vector2(2f, 2f));
            var rectangleCollider = new RectangleColliderComponent(gameObject, rectangleBounds);

            Assert.IsTrue(
                rectangleCollider.gameObject != null &&
                new Vector2(2f, 2f) == rectangleCollider.bounds.size &&
                !rectangleCollider.isTrigger &&
                !rectangleCollider.isStatic);
        }

        [TestMethod]
        public void RectangleColliderTest1()
        {
            var gameObject = new GameObject();
            var rectangleBounds = new RectangleBounds(new Vector2(3f, 3f));
            var rectangleCollider = new RectangleColliderComponent(gameObject, rectangleBounds, true);

            Assert.IsTrue(
                rectangleCollider.gameObject != null &&
                new Vector2(3f, 3f) == rectangleCollider.bounds.size &&
                rectangleCollider.isTrigger &&
                !rectangleCollider.isStatic);
        }

        [TestMethod]
        public void RectangleColliderTest2()
        {
            var gameObject = new GameObject();
            var rectangleBounds = new RectangleBounds(new Vector2(4f, 4f));
            var rectangleCollider = new RectangleColliderComponent(gameObject, rectangleBounds, true, true);

            Assert.IsTrue(
                rectangleCollider.gameObject != null &&
                new Vector2(4f, 4f) == rectangleCollider.bounds.size &&
                rectangleCollider.isTrigger &&
                rectangleCollider.isStatic);
        }
    }
}