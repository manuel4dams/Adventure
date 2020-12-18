using System.Diagnostics.CodeAnalysis;
using Framework.Transform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.TransformTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TransformTests
    {
        // testcase 1: no values
        [TestMethod]
        public void TransformTest_NoValues()
        {
            var transform = new Transform();

            Assert.IsTrue(transform.position == new Vector2(0f, 0f) &&
                          transform.rotation == 0f &&
                          transform.scale == new Vector2(1f, 1f)
            );
        }

        // testcase 7: with position, rotation, scale
        [TestMethod]
        public void TransformTest_AllValues()
        {
            var transform = new Transform();
            transform.position = new Vector2(1f, 1f);
            transform.rotation = 90f;
            transform.scale = new Vector2(3f, 3f);

            Assert.IsTrue(transform.position == new Vector2(1f, 1f) &&
                          transform.rotation == 90f &&
                          transform.scale == new Vector2(3f, 3f)
            );
        }
        
        // testcase 1: apply no values
        [TestMethod]
        public void ApplyTest_NoValues()
        {
            var transformA = new Transform();
            var transformB = new Transform();
            
            transformA.Apply(transformB);
            
            Assert.IsTrue(transformA.position == new Vector2(0f, 0f) &&
                          transformA.rotation == 0f &&
                          transformA.scale == new Vector2(1f, 1f)
            );
        }

        // testcase 7: apply position, rotation, scale
        [TestMethod]
        public void ApplyTest_AllValues()
        {
            var transformA = new Transform();
            var transformB = new Transform();
            transformB.position = new Vector2(2f, 2f);
            transformB.rotation = 90f;
            transformB.scale = new Vector2(3f, 3f);
            
            transformA.Apply(transformB);

            Assert.IsTrue(transformA.position == new Vector2(2f, 2f) &&
                          transformA.rotation == 90f &&
                          transformA.scale == new Vector2(3f, 3f)
            );
        }

        // testcase 1: apply new position
        [TestMethod]
        public void TranslateTest()
        {
            var transform = new Transform();

            transform.Translate(new Vector2(3f, 3f));

            Assert.IsTrue(transform.position == new Vector2(3f, 3f) &&
                          transform.rotation == 0f &&
                          transform.scale == new Vector2(1f, 1f)
            );
        }

        // testcase 1: apply new position
        [TestMethod]
        public void TranslatePositionTest()
        {
            var transform = new Transform();

            var position = transform.TranslatePosition(new Vector2(4f, 4f));

            Assert.IsTrue(position == new Vector2(4f, 4f));
        }
    }
}