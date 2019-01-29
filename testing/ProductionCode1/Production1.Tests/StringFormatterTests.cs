using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductionCode1;

namespace ProductionCode.Tests
{
    [TestClass]
    public class StringFormatterTests
    {
        [TestMethod]
        public void TestSafeStringOnSelectQuery()
        {
            StringFormatter stringFormatter = new StringFormatter();

            string str = stringFormatter.SafeString("select 'id' from 'table' where 'id' = '1'");

            Assert.AreEqual(str, "SELECT ''id'' from ''table'' where ''id'' = ''1''");
        }

        [TestMethod]
        public void TestSafeStringOnStringEmpty()
        {
            StringFormatter stringFormatter = new StringFormatter();

            string str = stringFormatter.SafeString(string.Empty);

            Assert.AreEqual(str, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestSafeStringOnArgumentNullException()
        {
            StringFormatter stringFormatter = new StringFormatter();

            string str = stringFormatter.SafeString(null);
        }
    }
}
