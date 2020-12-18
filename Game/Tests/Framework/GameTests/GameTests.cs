using System.Diagnostics.CodeAnalysis;
using Framework.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.GameTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameTests
    {
        [TestMethod]
        public void GameTest()
        {
            Assert.IsTrue(Game.instance != null);
        }
    }
}