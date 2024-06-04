using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SeleniumTests
{
    [TestFixture]
    // This class contains test cases for successful scenarios
    public class SuccessfulTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        // This method sets up the test environment before each test
        public void SetupTest()
        {
            driver = new ChromeDriver(); // Initialize the ChromeDriver
            baseURL = "https://www.google.com/"; // Base URL for the tests
            verificationErrors = new StringBuilder(); // StringBuilder to store verification errors
        }
        
        [TearDown]
        // This method cleans up the test environment after each test
        public void TeardownTest()
        {
            try
            {
                driver.Quit(); // Quit the driver
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString()); // Assert that there are no verification errors
        }
        
        [Test]
        // This is the test case for successful login
        public void TheSuccessfulTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://letsusedata.com/CourseSelection.html"); // Navigate to the test page
            driver.FindElement(By.Id("txtUser")).Click(); // Click on the username field
            driver.FindElement(By.Id("txtUser")).Clear(); // Clear the username field
            driver.FindElement(By.Id("txtUser")).SendKeys("test1"); // Enter the username
            driver.FindElement(By.Id("txtPassword")).Click(); // Click on the password field
            driver.FindElement(By.Id("txtPassword")).Clear(); // Clear the password field
            driver.FindElement(By.Id("txtPassword")).SendKeys("Test12456"); // Enter the password
            driver.FindElement(By.Id("javascriptLogin")).Click(); // Click on the login button
            Thread.Sleep(2000); // Wait for 2 seconds
            Assert.AreEqual("Test Course", driver.FindElement(By.Id("11CourseTitle")).Text); // Assert that the course title is as expected
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by); // Try to find the element
                return true; // Return true if the element is found
            }
            catch (NoSuchElementException)
            {
                return false; // Return false if the element is not found
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert(); // Try to switch to the alert
                return true; // Return true if the alert is present
            }
            catch (NoAlertPresentException)
            {
                return false; // Return false if the alert is not present
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert(); // Switch to the alert
                string alertText = alert.Text; // Get the text of the alert
                if (acceptNextAlert) {
                    alert.Accept(); // Accept the alert if acceptNextAlert is true
                } else {
                    alert.Dismiss(); // Dismiss the alert if acceptNextAlert is false
                }
                return alertText; // Return the text of the alert
            } finally {
                acceptNextAlert = true; // Reset acceptNextAlert to true
            }
        }
    }
}