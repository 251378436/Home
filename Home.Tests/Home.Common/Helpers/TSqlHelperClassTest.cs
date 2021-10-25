using Home.Common.Helpers;
using Home.Common.Models;
using NUnit.Framework;

namespace Home.Tests.Home.Common.Helpers
{
    public class TSqlHelperClassTest
    {
        /// <summary>
		/// Test the Constructor() method
		/// Check if the Find, FindAll, Insert, Update, Delete sql are generated correctly For SalesOrder Class.
		/// </summary>
        [Test]
        public void Test_Constructor_SalesOrderTypeSqlCreatedCorrectly()
        {
            // Check the Sql
            Assert.AreEqual("SELECT [Customer],[Amount],[Discount],[Id],[Description] FROM [SalesOrder];", TSqlHelper<SalesOrder>.FindAllSql);
            Assert.AreEqual("SELECT [Customer],[Amount],[Discount],[Id],[Description] FROM [SalesOrder] where Id =", TSqlHelper<SalesOrder>.FindSql);
            Assert.AreEqual("INSERT INTO [SalesOrder] ([Customer],[Amount],[Discount],[Description]) OUTPUT Inserted.ID VALUES (@Customer,@Amount,@Discount,@Description);", TSqlHelper<SalesOrder>.InsertSql);
            Assert.AreEqual("UPDATE [SalesOrder] SET [Customer]=@Customer,[Amount]=@Amount,[Discount]=@Discount,[Description]=@Description where Id=", TSqlHelper<SalesOrder>.UpdateSql);
            Assert.AreEqual("DELETE FROM [SalesOrder] where Id =", TSqlHelper<SalesOrder>.DeleteSql);
        }
    }
}