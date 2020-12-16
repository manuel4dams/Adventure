using Framework.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.Objects
{
    [TestClass]
    public class GameTests
    {
        // functional test NA, this would be a system test
        [Ignore]
        [TestMethod]
        public void RunTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AddGameObjectTest()
        {
            Game.instance.AddGameObject(new TestGameOBject());
            Assert.IsTrue(Game.instance.gameObjects.Count == 1);
        }
    }

    public class TestGameOBject : GameObject
    {
    }
}