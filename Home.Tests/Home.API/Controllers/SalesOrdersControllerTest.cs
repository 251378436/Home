using Home.API.Controllers;
using Home.Common.DAL;
using Home.Common.Factory;
using Home.Common.Grains;
using Home.Common.Models;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace Home.Tests.Home.API.Controllers
{
    public class SalesOrdersControllerTest
    {
        private SalesOrdersController controller;

        [SetUp]
        public void Setup()
        {
            // get current path and DB file path
            var currentPath = Directory.GetCurrentDirectory();
            var basePath = currentPath.Split("Home.Tests")[0];
            var dbPath = $@"{basePath}Home.API\App_Data";

            // make use of reflection to change the connection string
            DBFactory dBFactory = new DBFactory();
            Type type = typeof(DBFactory);
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var fieldInfo = type.GetField("connectionString", bindFlags);
            var connection = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath}\Database.mdf;Integrated Security=True";
            fieldInfo.SetValue(dBFactory, connection);

            // create instances
            IDAL dal = new DAL(dBFactory);
            ISalesOrdersGrain salesOrdersGrain = new SalesOrdersGrain(dal);

            // Arrange
            this.controller = new SalesOrdersController(null, salesOrdersGrain);
        }

        [Test]
        public void Test_GetSalesOrder()
        {
            // Act
            var actionResult = this.controller.GetSalesOrder(1);
            var result = (SalesOrder)actionResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("City Council", result.Customer);
        }
    }
}