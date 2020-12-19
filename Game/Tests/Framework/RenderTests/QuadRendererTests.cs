using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
            var quadRenderer = new RectangleColorRenderer(gameObject, bounds);
            Assert.IsTrue(quadRenderer.gameObject != null);
        }

        [TestMethod]
        public void QuadRendererTest1()
        {
            var gameObject = new GameObject();
            var bounds = new RectangleBounds();
            var quadRenderer = new RectangleColorRenderer(gameObject, bounds, Color.Olive);
            Assert.IsTrue(quadRenderer.gameObject != null);
        }
    }
}