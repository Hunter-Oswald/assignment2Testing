using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Assignment02_22F
{
    [TestClass]
    public class CarStoreTests
    {
        //WebDriver object pointing to the browser
        private IWebDriver? driver;

        //To hold the path to VehicleStore directory in the compiled folder
        private string rootPath = "";


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            //Set to the path to VehicleStore directory in the compiled folder
            rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VehicleStore");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (driver is not null)
            {
                driver.Quit();
            }
        }

        //Example showing you how to use the rootPath variable to get to any page of the VehicleStore.
        /*[TestMethod]
        public void TestExample()
        {
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "login.html"));
        }*/

        // Test 1 - navigation from the homepage to admin page
        [TestMethod]
        public void navigateFromHome_ToAdminPage()
        {
            // start at the home page
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "index.html"));

            // press button
            IWebElement buttonHomeToAdmin = driver.FindElement(By.Id("goAdmin"));
            buttonHomeToAdmin.Click();

            // Assert
            // Make sure on the right page
            Assert.IsTrue(driver.Url.Contains("admin.html"));
            
        }

        // Test 2 - navigation from admin to new postings
        [TestMethod]
        public void navigateFromAdmin_ToPostNewListings()
        {
            // start at admin page
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "admin.html"));

            // press button
            IWebElement buttonAdminToNewpost = driver.FindElement(By.Id("goNew"));
            buttonAdminToNewpost.Click();

            // Assert
            // Make sure on the right page
            Assert.IsTrue(driver.Url.Contains("new.html"));

        }

        // Test 3 - navigation from cars for sale to home page
        [TestMethod]
        public void navigateFromSale_ToHome()
        {
            // start at cars for sale
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "sale.html"));

            // press button
            IWebElement buttonSaleToHome = driver.FindElement(By.Id("goHome"));
            buttonSaleToHome.Click();

            // Assert
            // make sure on the right page
            Assert.IsTrue(driver.Url.Contains("index.html"));
        }

        // Test 4 - logging in
        [TestMethod]
        public void enterLogin_andSubmit()
        {
            // start at the login page
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "login.html"));

            // enter all the input
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement submitButton = driver.FindElement(By.Id("formSubmit"));

            usernameInput.SendKeys("user");
            passwordInput.SendKeys("pass");

            // press login
            submitButton.Click();

            // Assert
            // make sure on the right page; should take you to home page
            Assert.IsTrue(driver.Url.Contains("index.html"));
        }

        // Test 5 - loggin in with incorrect information
        [TestMethod]
        public void enterLogin_WrongInfo()
        {
            // start at the login page
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "login.html"));

            // enter all the input (incorrect login information)
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement submitButton = driver.FindElement(By.Id("formSubmit"));

            usernameInput.SendKeys("false");
            passwordInput.SendKeys("info");

            // press login
            submitButton.Click();

            // Assert
            // make sure on the right page; should leave you at the login page
            Assert.IsTrue(driver.Url.Contains("login.html"));
        }
    }
}