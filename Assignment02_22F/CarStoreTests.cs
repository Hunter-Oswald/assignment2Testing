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

        //Example showing you how to use the rootPath variable to get to any page of the VehicleStore
        [TestMethod]
        public void TestExample()
        {
            driver.Navigate().GoToUrl(Path.Combine(rootPath, "login.html"));
        }
    }
}