using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private DatabaseConnection _dbConnection;
        [TestMethod]
        public void TestMethod1()
        {
            

            
        }

        [TestMethod]
        public void InlogTest()
        {
            _dbConnection = new DatabaseConnection();

            string test = Convert.ToString(_dbConnection.Login("Ichsadadae", "WieBenJij"));

            Assert.IsNull(test);
        }
    }
}
