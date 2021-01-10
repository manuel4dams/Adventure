using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Framework.Game;
using Framework.Interfaces;
using Framework.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForestAdventure.Framework.UtilTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LinqExtensionTests
    {
        [TestMethod]
        public void ForEachTest()
        {
            List<IComponent> list = new List<IComponent>();
            var testBool = false;

            list.Add(new Component());
            list
                .AsEnumerable()
                .ForEach(component => testBool = true);

            Assert.IsTrue(!testBool);
        }

        [TestMethod]
        public void EvaluateTest()
        {
            List<IComponent> list = new List<IComponent>();
            var testBool = false;

            list.Add(new Component());
            list
                .AsEnumerable()
                .ForEach(component => testBool = true)
                .Evaluate();

            Assert.IsTrue(testBool);
        }
    }

    internal class Component : IComponent
    {
        public GameObject gameObject { get; }
    }
}