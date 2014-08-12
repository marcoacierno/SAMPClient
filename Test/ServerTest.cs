using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SAMPClient.Test
{
    [TestFixture]
    class ServerTest
    {
        [Test]
        public void NotEqualTest()
        {
            var s1 = new Server("..:: HostName ::..", "1.2.3.4", 1234);
            var s2 = new Server("..:: No Hostname ::..", "2.4.5.6", 1234);

            Assert.AreNotEqual(s1, s2);
        }

        [Test]
        public void EqualTest()
        {
            var s1 = new Server("..:: HostName ::..", "1.2.3.4", 1234);
            var s2 = new Server("..:: HostName ::..", "1.2.3.4", 1234);

            Assert.AreEqual(s1, s2);
        }

        [Test]
        public void EqualWithNull()
        {
            var s1 = new Server("..:: HostName ::..", "1.2.3.4", 1234);

            Assert.AreNotEqual(s1, null);
        }
    }
}
