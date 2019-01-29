using ConsoleAppElComercio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProjectElComercio
{
 
    [TestClass]
    public class MoneyPartsTest
    {
        [TestMethod]
        public void TestBuildMoneyParts()
        {

            var moneyParts = new MoneyParts();
            Assert.AreEqual(moneyParts.Build(0.1m).Count(), 2);
        }

    }
}
