namespace TestAutomation
{
    [TestFixture()]
    public class TestRunner 
    {
        readonly WebDriver driver = new WebDriver();
        LoginPage? loginPage;
        MainPage? mainPage;

        [OneTimeSetUp]
        public void Init()
        {
            navigateToLoginPage();
        }        


        #region Navigate to the login page [Numbers 1 -100]

        public void navigateToLoginPage()
        {
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
        }

        [Test, Order(1)]
        public void checkLoginPage()
        {
            loginPage?.IsThisLoginPage();
        }

        #endregion

        #region Login to the system [Numbers 101 -200]

        [Test, Order(101)]
        public void TestLogin()
        {
            loginPage?.Login(driver.Username, driver.Password);
        }

        [Test, Order(102)]
        public void CheckLogin()
        {
            mainPage = new MainPage(driver);
            mainPage.VerifyLogin();
        }

        [Test, Order(103)]
        public void CheckContacts()
        {
            mainPage?.CheckContacts();
        }

        [Test, Order(104)]
        public void CheckBroadcast()
        {
            mainPage?.CheckBroadcast();
        }

        [Test, Order(105)]
        public void CheckAutomation()
        {
            mainPage?.CheckAutomation();
        }

        #endregion


        //This reagions test cases should be the last couple of test cases. Please change the numbers accordingly
        #region Sign out check [Numbers 201 -300]


        [Test, Order(201)]
        public void TestLogOut()
        {
            mainPage?.SignOut();
        }

        [Test, Order(202)]
        public void CheckLogOut()
        {
            loginPage?.IsThisLoginPage();
        }

        #endregion

        #region Exit from the driver

        [OneTimeTearDown]
        public void TearDown() => driver.Driver.Quit();

        #endregion
    }
}

