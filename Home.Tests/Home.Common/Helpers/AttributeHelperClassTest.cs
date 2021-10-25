using Home.Common.Helpers;
using Home.Common.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace Home.Tests.Home.Common.Helpers
{
    public class AttributeHelperClassTest
    {
        /// <summary>
		/// Test the GetDBProperties() method
		/// Check if the returned Properties has the correct count.
		/// </summary>
        [Test]
        [TestCase(typeof(SalesOrder), 5)]
        [TestCase(typeof(SalesOrderItem), 7)]
        public void Test_GetDBProperties_ReturnTheCorrectCountOfProperties(Type type, int count)
        {
            // Check the count
            Assert.AreEqual(count, type.GetDBProperties().Count());
        }
    }
}