using System.Diagnostics.CodeAnalysis;
using Framework.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using GameWindow = Framework.Game.GameWindow;

namespace UnitTestForestAdventure.Framework.GameTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameWindowTests
    {
        [TestMethod]
        public void GameWindowTest()
        {
            var gameWindow = new GameWindow(Game.instance);

            Assert.IsTrue(gameWindow.WindowState == WindowState.Normal);
        }
    }
}