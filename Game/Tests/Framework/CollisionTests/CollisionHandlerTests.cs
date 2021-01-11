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
    public class CollisionHandlerTests
    {
        [TestMethod]
        public void HandleCollisionTest()
        {
            var gameObjectA = new GameObject();
            var rectangleBoundsA = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var colliderA = new RectangleColliderComponent(gameObjectA, rectangleBoundsA);
            gameObjectA.AddComponent(colliderA);
            gameObjectA.transform.position = Vector2.Zero;

            var gameObjectB = new GameObject();
            var rectangleBoundsB = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var colliderB = new RectangleColliderComponent(gameObjectB, rectangleBoundsB);
            gameObjectB.AddComponent(colliderB);
            gameObjectB.transform.position = Vector2.One;

            CollisionHandler.HandleCollision(colliderA, colliderB);

            // no good unit test, it basically tests nothing...
            // impractical to write good test at this moment
            Assert.IsTrue(
                Vector2.Zero == gameObjectA.transform.position &&
                Vector2.One == gameObjectB.transform.position
            );
        }
    }
}