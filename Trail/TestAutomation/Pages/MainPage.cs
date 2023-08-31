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

        public IWebElement ProfileAvatarButton => webDriver.Driver.FindElement(By.XPath("//div[@data-testid='headerNavBar-accountDrawer']"));

        public IWebElement SignoutBtn => webDriver.Driver.FindElement(By.XPath("//button[@color='primary' and contains(text(), 'Sign out')]"));

        public IWebElement SignoutConfirmedBtn => webDriver.Driver.FindElement(By.XPath("//button[@color='negative' and contains(text(), 'Sign out')]"));

         public void VerifyLogin()
        {
            var messageButton = webDriver.Driver.FindElement(By.CssSelector("[data-testid='teamInbox-leftSide-actionBar-newMessage-button']"));
            // Assert.That(messageButton.Displayed, Is.True);
            Task.Delay(1000).Wait();
            // Find the button element using CSS selector
            //IWebElement buttonElement = webDriver.Driver.FindElement(By.CssSelector("button.MuiButtonBase-root.MuiIconButton-root.MuiIconButton-sizeMedium.css-1yxmbwk"));

            // Click on the button
            // messageButton.Click();
            Task.Delay(1000).Wait();
        }


        // public void ActiveChat()
        // {
        //     // Find the button element using CSS selector
        //     //IWebElement buttonElement = webDriver.Driver.FindElement(By.CssSelector("button.MuiButtonBase-root.MuiIconButton-root.MuiIconButton-sizeMedium.css-1yxmbwk"));
        //     IWebElement buttonElement = webDriver.Driver.FindElement(By.CssSelector("div.ball-status.Open"));

        //     // Click on the button
        //     buttonElement.Click();
        //     Task.Delay(1000).Wait();
        //     WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
        //     Task.Delay(1000).Wait();
        //     // Find the div element
        //     //IWebElement divElement = webDriver.Driver.FindElement(By.CssSelector("div.sc-gPEVay.lnVIqG.selected-item"));

        //     // Find the inner <span> element
        //     //IWebElement spanElement = divElement.FindElement(By.TagName("span"));

        //     // Get the inner HTML of the <span> element
        //     //string spanInnerHTML = spanElement.GetAttribute("innerHTML");
        //     //if(spanInnerHTML!="Active chats")
        //     //{
        //     //    IWebElement menu = webDriver.Driver.FindElement(By.CssSelector("[role='menu']"));
        //     //    menu.Click();
        //     //    Task.Delay(1000).Wait();
        //     //    IWebElement activeChatsDiv = webDriver.Driver.FindElement(By.CssSelector("div.option:has(div.option-label:contains('Active chats'))"));
        //     //    activeChatsDiv.Click();
        //     //    Task.Delay(1000).Wait();

        //     //}
        //     //Find the element by its 'role' attribute and value
            
        //     // Find the element by CSS selector
        //     IWebElement chat = webDriver.Driver.FindElement(By.CssSelector(".ball-status.Open"));

        //     // Add a click event to the element
        //     chat.Click();

           
        //     Task.Delay(1000).Wait();
        //     // Find the textarea element by CSS selector
        //     IWebElement textarea = webDriver.Driver.FindElement(By.CssSelector("textarea.chat-input__field"));

        //     // Clear the existing content if needed
        //     textarea.Clear();
        //     Task.Delay(1000).Wait();
        //     // Input text into the textarea using SendKeys
        //     textarea.SendKeys("Hello, how are you?");
        //     Task.Delay(1000).Wait();
        //     IWebElement sendButton = webDriver.Driver.FindElement(By.CssSelector("div.btn-send"));
        //     sendButton.Click();

        //     Task.Delay(1000).Wait();

           
        // }
        // public void UpdateStatus(string Status)
        // {
        //     string requiredStatus = Status;
        //     string status = Status.ToLower();
        //     //var SubmitAsButton = webDriver.Driver.FindElement(By.CssSelector("[data-testid='teamInbox-content-chatHeaderV2-submitAs-dropdown']"));
        //     var SubmitAsButton = webDriver.Driver.FindElement(By.CssSelector("div.sc-ccXozh.kzbXCu"));
        //     var statusIcon = webDriver.Driver.FindElement(By.CssSelector("[data-testid='teamInbox-leftSide-conversationList-statusName']"));
        //     var initialStatus = statusIcon.GetAttribute("innerHTML");
        //     SubmitAsButton.Click();
        //     WebDriverWait wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
        //     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector($"[data-testid='teamInbox-content-chatHeaderV2-submitAs-dropdown-{status}']")));
        //     var pendingButton = webDriver.Driver.FindElement(By.CssSelector($"[data-testid='teamInbox-content-chatHeaderV2-submitAs-dropdown-{status}']"));
        //     pendingButton.Click();
        //     Console.WriteLine("status button clicked");
        //     WebDriverWait wait2 = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));

        //     if (status == "solved")
        //     {
        //         Console.WriteLine("inside solved");
        //         wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[class='sc-iAyFgw kaJrPq']")));
        //         var ReopenChatButton = webDriver.Driver.FindElement(By.CssSelector($"[class='sc-iAyFgw kaJrPq']"));

        //         Assert.That(ReopenChatButton.Displayed, Is.True);
        //         ReopenChatButton.Click();
        //         Task.Delay(1000).Wait();
        //         return;

        //     }
        //     if (status == "open")
        //     {
        //         initialStatus = "closed";
        //     }
        //     wait2.Until(driver =>
        //     {
        //         string currentInnerHTML = statusIcon.GetAttribute("innerHTML");
        //         return currentInnerHTML != initialStatus;
        //     });
        //     var newStatus = statusIcon.GetAttribute("innerHTML");
        //     Console.WriteLine(initialStatus);
        //     Console.WriteLine(newStatus);



        //     Console.WriteLine(requiredStatus);

        //     Assert.That(requiredStatus, Is.EqualTo(newStatus));

        //     SubmitAsButton.Click();
        //     WebDriverWait wait3 = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(15));
        //     wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='teamInbox-content-chatHeaderV2-submitAs-dropdown-open']")));
        //     var openButton = webDriver.Driver.FindElement(By.CssSelector("[data-testid='teamInbox-content-chatHeaderV2-submitAs-dropdown-open']"));
        //     openButton.Click();
        //     Task.Delay(1000).Wait();

        // }

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
