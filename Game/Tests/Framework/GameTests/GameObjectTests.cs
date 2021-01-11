using System.Diagnostics.CodeAnalysis;
using Framework.Game;
using Framework.Interfaces;
using Framework.Transform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.GameTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameObjectTests
    {
        [TestMethod]
        public void GameObjectTest()
        {
            var gameObject = new GameObject();
            Assert.IsTrue(gameObject.transform != null);
        }

        [TestMethod]
        public void GameObjectTest1()
        {
            var transform = new Transform();
            transform.scale = new Vector2(2f, 2f);

            var gameObject = new GameObject(transform);
            Assert.IsTrue(
                gameObject.transform != null &&
                gameObject.transform.scale == new Vector2(2f, 2f)
            );
        }

        [TestMethod]
        public void AddComponentTest()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent(new TestComponent());
            Assert.IsTrue(gameObject.components.Count == 1);
        }

        [TestMethod]
        public void RemoveComponentTest()
        {
            var gameObject = new GameObject();
            var testComponent = new TestComponent();
            gameObject.AddComponent(testComponent);
            Assert.IsTrue(gameObject.components.Count == 1);

            gameObject.RemoveComponent(testComponent);
            Assert.IsTrue(gameObject.components.Count == 0);
        }
    }


    public class TestComponent : IComponent
    {
        public GameObject gameObject { get; }
    }
}