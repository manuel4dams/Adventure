using Framework.Game;
using Framework.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.Objects
{
    [TestClass]
    public class GameObjectTests
    {
        // functional test NA for constructor
        [Ignore]
        [TestMethod]
        public void GameObjectTest()
        {
            Assert.Fail();
            // testcase 1: call first constructor
        }

        // functional test NA for constructor
        [Ignore]
        [TestMethod]
        public void GameObjectTest1()
        {
            Assert.Fail();
            // testcase 1: call second constructor
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