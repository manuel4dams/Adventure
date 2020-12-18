using System.Diagnostics.CodeAnalysis;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK.Graphics;

namespace UnitTestForestAdventure.Framework.RenderTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class QuadRendererTests
    {
        [TestMethod]
        public void QuadRendererTest()
        {
            var gameObject = new GameObject();
            var bounds = new RectangleBounds();
            var quadRenderer = new QuadRenderer(gameObject, bounds);
            Assert.IsTrue(quadRenderer.gameObject != null);
        }

        [TestMethod]
        public void QuadRendererTest1()
        {
            var gameObject = new GameObject();
            var bounds = new RectangleBounds();
            var quadRenderer = new QuadRenderer(gameObject, bounds, Color4.Olive);
            Assert.IsTrue(quadRenderer.gameObject != null);
        }
    }
}