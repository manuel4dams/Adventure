using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.Collision
{
    [TestClass]
    public class CollisionCalculatorTests
    {
        // functional test NA would only test which class gets called
        [Ignore]
        [TestMethod]
        public void UnrotatedIntersectsTest()
        {
            Assert.Fail();
            // case 1: first collider is rectangle, second is rectangle

            // case 2: first collider is rectangle, second is circle

            // default 2: wrong collider type for second collider

            // case 3: first collider is circle, second is rectangle

            // case 4: first collider is circle, second is circle

            // default 3: wrong collider type for second collider

            // default 1: wrong collider type for first collider
        }

        // functional test NA would only test which class gets called
        [Ignore]
        [TestMethod]
        public void UnrotatedOverlapTest()
        {
            Assert.Fail();
            // case 1: first collider is rectangle, second is rectangle

            // case 2: first collider is rectangle, second is circle

            // default 2: wrong collider type for second collider

            // case 3: first collider is circle, second is rectangle

            // case 4: first collider is circle, second is circle

            // default 3: wrong collider type for second collider

            // default 1: wrong collider type for first collider
        }
    }
}