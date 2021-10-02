using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_laba.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void CompareTest_1()
        {
            int n=2;
            string s="14 14 56 78 95";
            var message = Logic.Compare(n, s);
            Assert.AreEqual("0 1", message);

        }
        [TestMethod()]
        public void CompareTest_2()
        {
            int n = 3;
            string s = "14 1 56 78 95";
            var message = Logic.Compare(n, s);
            Assert.AreEqual("Возможных пар не обнаружено", message);

        }
        [TestMethod()]
        public void CompareTest_3()
        {
            int n = 3;
            string s = "3 4 6 7 7 7 8";
            var message = Logic.Compare(n, s);
            Assert.AreEqual("3 4 5", message);

        }
    }
}