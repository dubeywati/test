using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation
{
    internal class MainPage 
    {
        readonly WebDriver webDriver;
        public MainPage(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement ProfileAvatarButton => webDriver.Driver.FindElement(By.CssSelector("[aria-label='account of current user']"));

        public IWebElement SignoutBtn => webDriver.Driver.FindElement(By.CssSelector("[data-testid='profileMenu-firstGroup-signOut-button']"));

        public IWebElement SignoutConfirmedBtn => webDriver.Driver.FindElement(By.CssSelector("[data-testid='modals-confirmDialog-content-buttons-negative-button']"));

        public void VerifyLogin()
        {
            var messageButton = webDriver.Driver.FindElement(By.CssSelector("[data-testid='teamInbox-leftSide-actionBar-newMessage-button']"));
            Assert.That(messageButton.Displayed, Is.True);
            Task.Delay(1000).Wait();
        }       


        public void CheckContacts()
        {
            var ContactsTab = webDriver.Driver.FindElement(By.CssSelector("[data-testid='headerNavBar-menuNavItem-contacts-link']"));
            ContactsTab.Click();
            WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='contacts-header-addContact-button']")));
            var addContactBtn = webDriver.Driver.FindElement(By.CssSelector("[data-testid='contacts-header-addContact-button']"));
            Assert.That(addContactBtn.Displayed, Is.True);
            Task.Delay(1000).Wait();
        }

       
        public void CheckBroadcast()
        {     
            var BroadcastTab = webDriver.Driver.FindElement(By.CssSelector("[data-testid='headerNavBar-menuNavItem-broadcast-link']"));
            BroadcastTab.Click();
            WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='broadCastHistory-statusBar-newBroadCast-button']")));
            var newBroadcastBtn = webDriver.Driver.FindElement(By.CssSelector("[data-testid='broadCastHistory-statusBar-newBroadCast-button']"));
            Assert.That(newBroadcastBtn.Displayed, Is.True);
            Task.Delay(1000).Wait();

        }

        public void CheckAutomation()
        {           
            var AutomationTab = webDriver.Driver.FindElement(By.CssSelector("[data-testid='headerNavBar-menuNavItem-automation-link']"));
            AutomationTab.Click();
            WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='defaultAction-workingHoursPane-setWorkingHours-button']")));
            var setWorkingHoursBtn = webDriver.Driver.FindElement(By.CssSelector("[data-testid='defaultAction-workingHoursPane-setWorkingHours-button']"));
            Assert.That(setWorkingHoursBtn.Displayed, Is.True);
            Task.Delay(1000).Wait();
        }

        public void SignOut()
        { 
            ProfileAvatarButton.Click();
            Task.Delay(1000).Wait();
            SignoutBtn.Click();
            Task.Delay(1000).Wait();
            SignoutConfirmedBtn.Click();
            Task.Delay(1000).Wait();
        }
    }
}
