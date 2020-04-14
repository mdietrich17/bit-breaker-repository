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
        //Maddy's Test - Testing if HomeController Index (main page) returns null or some value
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

        //Maddy's Test - Testing if Help Page ViewBag Message is correct.
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

            [TestMethod]
            public void Index() // Mike's test for ensuring main welcome page is functioning. 
            {
                // Arrange
                HomeController controller = new HomeController();
                // Act
                ViewResult result = controller.Index() as ViewResult;
                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod] // Mike's test for services page. 
            public void Services()
            {
                // Arrange
                HomeController controller = new HomeController();
                // Act
                // Assert
                if (controller.Services() is ViewResult result)
                    Assert.AreEqual("Services that are offered in our community.", result.ViewBag.Message);
            }

        [TestMethod] // Jon's tests for user Home page view message
        public void HomePageTest()
        {

            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ForgotPasswordConfirmation() as ViewResult;
            //Assert
            Assert.AreEqual(null, result.ViewBag.Message);
        }

        [TestMethod] // Jon's test for Account registration view message
        public void RegistrationMessageTest()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.Register() as ViewResult;
            //Assert
            Assert.AreEqual(null, result.ViewBag.Message);

        }

        [TestMethod]
        public void Login() //Dennis' Test for the login page. 
        {
            AccountController controller = new AccountController();
            if (controller.Login(null) is ViewResult result)
            {
                Assert.AreEqual(null, result.ViewBag.Message);
            }
        }
    }
}
