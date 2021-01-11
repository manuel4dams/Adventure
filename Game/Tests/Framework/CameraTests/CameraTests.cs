using System.Diagnostics.CodeAnalysis;
using Framework.Camera;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.CameraTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CameraTests
    {
        [TestMethod]
        public void CameraTest()
        {
            new Camera(Camera.ResizeViewport.KeepContentAspectRatio);

            Assert.IsTrue(Camera.instance != null);
        }
    }
}