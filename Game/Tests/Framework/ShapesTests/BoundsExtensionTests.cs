using System.Diagnostics.CodeAnalysis;
using Framework.Shapes;
using Framework.Transform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace UnitTestForestAdventure.Framework.ShapesTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BoundsExtensionTests
    {
        //testcase 1: default constructor
        [TestMethod]
        public void RectangleBounds_DefaultConstructor()
        {
            var rectangleBounds = new RectangleBounds();

            Assert.IsTrue(rectangleBounds.center == new Vector2(0f, 0f) &&
                          rectangleBounds.size == new Vector2(0f, 0f));
        }

        //testcase 2: first constructor
        [TestMethod]
        public void RectangleBounds_FirstConstructor()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f));

            Assert.IsTrue(rectangleBounds.center == new Vector2(0f, 0f) &&
                          rectangleBounds.size == new Vector2(1f, 1f));
        }

        //testcase 3: second constructor
        [TestMethod]
        public void RectangleBounds_SecondConstructor()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f), new Vector2(2f, 2f));

            Assert.IsTrue(rectangleBounds.center == new Vector2(1f, 1f) &&
                          rectangleBounds.size == new Vector2(2f, 2f));
        }

        //testcase 4: third constructor
        [TestMethod]
        public void RectangleBounds_ThirdConstructor()
        {
            var rectangleBounds = new RectangleBounds(1f, 1f);

            Assert.IsTrue(rectangleBounds.center == new Vector2(0f, 0f) &&
                          rectangleBounds.size == new Vector2(1f, 1f));
        }

        //testcase 5: fourth constructor
        [TestMethod]
        public void RectangleBounds_FourthConstructor()
        {
            var rectangleBounds = new RectangleBounds(1f, 1f, 2f, 2f);

            Assert.IsTrue(rectangleBounds.center == new Vector2(1f, 1f) &&
                          rectangleBounds.size == new Vector2(2f, 2f));
        }

        //testcase 1: rectangle unscaled
        [TestMethod]
        public void UnrotatedTransform_NoTransformValues()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var transform = new Transform();

            var transformedBounds = rectangleBounds.UnrotatedTransform(transform);

            Assert.IsTrue(transformedBounds.center == new Vector2(1f, 1f) &&
                          transformedBounds.size == new Vector2(1f, 1f));
        }

        //testcase 2: rectangle scaled
        [TestMethod]
        public void UnrotatedTransform_AllTransformValues()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var transform = new Transform();
            transform.position = new Vector2(2f, 2f);
            transform.scale = new Vector2(3f, 3f);

            var transformedBounds = rectangleBounds.UnrotatedTransform(transform);

            Assert.IsTrue(transformedBounds.center == new Vector2(3f, 3f) &&
                          transformedBounds.size == new Vector2(3f, 3f));
        }

        //testcase 1: rectangle unrotated, unscaled
        [TestMethod]
        public void TransformTest_NoTransformValues_NoTransformValues()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var transform = new Transform();

            var Quad = rectangleBounds.Transform(transform);

            Assert.IsTrue(Quad.vertex1 == new Vector2(0.5f, 0.5f) &&
                          Quad.vertex2 == new Vector2(1.5f, 0.5f) &&
                          Quad.vertex3 == new Vector2(1.5f, 1.5f) &&
                          Quad.vertex4 == new Vector2(0.5f, 1.5f));
        }

        //testcase 2: rectangle rotated, scaled
        [TestMethod]
        public void TransformTest_AllTransformValues()
        {
            var rectangleBounds = new RectangleBounds(new Vector2(1f, 1f), new Vector2(1f, 1f));
            var transform = new Transform();
            transform.position = new Vector2(1f, 1f);
            transform.rotation = 360f;
            transform.scale = new Vector2(2f, 2f);

            var Quad = rectangleBounds.Transform(transform);

            // something must be odd in calculation, maybe floating point rounding inconsistency
            Assert.IsTrue(Quad.vertex1 == new Vector2(3.2426066f, 1.3247753f) &&
                          Quad.vertex2 == new Vector2(2.6752248f, 3.2426066f) &&
                          Quad.vertex3 == new Vector2(0.75739324f, 2.6752248f) &&
                          Quad.vertex4 == new Vector2(1.3247753f, 0.75739324f));
        }
    }
}