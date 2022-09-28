using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCode.Tests
{
    [TestClass()]
    public class FirstTestTests
    {

        FirstTest test = new FirstTest();

        [TestMethod()]
        public void showSavingAccTest()
        {
            int i = test.showSavingAcc();
            Assert.AreEqual(13200, i);
        }
    }
}