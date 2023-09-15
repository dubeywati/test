using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TestAutomation
{
    internal class LoginPage 
    {
        readonly WebDriver webDriver;
        public LoginPage(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement TxtEmail => webDriver.Driver.FindElement(By.Name("email"));

        public IWebElement TxtPassword => webDriver.Driver.FindElement(By.Name("password"));

        public IWebElement BtnLogin => webDriver.Driver.FindElement(By.XPath("//button[text()='Login']"));

        public bool IsBtnLoginExist => BtnLogin.Displayed;

        public void ClickLogin() => BtnLogin.Click();

        public void NavigateToLoginPage()
        {
            webDriver.Driver.Navigate().GoToUrl($"{webDriver.URL}/login");
            WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Login']")));
        }

        public void IsThisLoginPage()
        {
            Assert.That(webDriver.Driver.Title, Is.EqualTo("WATI - WhatsApp Team Inbox"));
        }

        public void Login(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            ClickLogin();

            WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='teamInbox-leftSide-actionBar-newMessage-button']")));
        }
    }
}
