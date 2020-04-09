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
    }

    [TestClass]
    public class EventsControllerTest
    {
        //Tests if event with ID 3 is the same as what is in the database for EventsController
        //Test is broken I need to fix!!
        [TestMethod]
        public void EventDetails()
        {
            // Arrange
            EventsController controller = new EventsController();
          
            // Act
            ViewResult result = controller.Details(3) as ViewResult;

            // Assert
            Assert.AreEqual("Your product was found", result.ViewBag.Message);
        }
    }
}
