using System;
using System.Web.Mvc;
using SimplySeniors.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplySeniors.DAL;
using SimplySeniors;
using SimplySeniors.Models;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace SimplySeniorsUnitTester
{
    [TestClass]
    public class HomeControllerTest
    {
        //Testing if HomeController Index (main page) returns null or some value
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        //Testing if Help Page ViewBag Message is correct.
        [TestMethod]
        public void HelpPageTest()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.HelpPage() as ViewResult;
            // Assert
            Assert.AreEqual("Your application help page.", result.ViewBag.Message);
        }
    }
}
