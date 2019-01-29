using ConsoleAppElComercio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProjectElComercio
{
    [TestClass]
    public class CompleteRangeTests
    {
        [TestMethod]
        public void buildTest()
        {
            var completeRange = new CompleteRange();

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 4, 5 }, completeRange.build(new List<int>() { 2, 1, 4, 5 }));
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, completeRange.build(new List<int>() { 4, 2, 9 }));
            CollectionAssert.AreEqual(Enumerable.Range(1, 60).ToList(), completeRange.build(new List<int>() { 58, 60, 55 }));
        }
    }
}
