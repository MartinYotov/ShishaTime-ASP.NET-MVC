using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsHub.Web.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void Test2()
        {
            Assert.IsFalse(false);
        }

        [Test]
        public void Test3()
        {
            int a = 5;

            Assert.AreEqual(5, a);
        }
    }
}
