using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplySeniors.Controllers;

namespace SimplySeniorsUnitTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class HomeControllerTest
        {

            [TestMethod]
            public void Index()
            {
                // Arrange


                HomeController controller = new HomeController();
                // Act
                ViewResult result = controller.Index() as ViewResult;
                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void Services()
            {
                // Arrange
                HomeController controller = new HomeController();
                // Act
                // Assert
                if (controller.Services() is ViewResult result)
                    Assert.AreEqual("Services that are offered in our community.", result.ViewBag.Message);
            }
        }
    }
}
