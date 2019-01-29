using ConsoleAppElComercio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppElComercio.test
{
    [TestClass]
    public class ChangeStringTests
    {
        [TestMethod]
        public void buildTest()
        {
            var classchangeString = new ChangeString();

            Assert.AreEqual("a", classchangeString.Build("z"));
            Assert.AreEqual("123 bcde*3", classchangeString.Build("123 abcd*3"));
            Assert.AreEqual("**Dbtb 52", classchangeString.Build("**Casa 52"));
        }
    }
}
