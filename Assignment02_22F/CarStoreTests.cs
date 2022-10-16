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

            IWebElement buttonHomeToAdmin = driver.FindElement(By.Id("goAdmin"));
            buttonHomeToAdmin.Click();

            Assert.IsTrue(driver.Url.Contains("admin.html"));
            
        }

        // Test 2 - navigation from admin to new postings
        [TestMethod]
        public void navigateFromAdmin_ToPostNewListings()
        {
            // start at admin page
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "admin.html"));

            IWebElement buttonAdminToNewpost = driver.FindElement(By.Id("goNew"));
            buttonAdminToNewpost.Click();

            Assert.IsTrue(driver.Url.Contains("new.html"));

        }

    }
}