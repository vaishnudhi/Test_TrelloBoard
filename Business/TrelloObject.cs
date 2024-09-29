using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_TrelloBoard.Business
{
    // This class is created on purpose to serve the business logic to the tests.
    // Also the methods can be reused across different scenarios
    internal class TrelloObject
    {
        private IWebDriver webDriver;
        public void initiatialiseWebDriver()
        {
            // I tried the tests with the ChromeDriver, We have the options to try in different browsers by initialising the webDriver of the respoective browser
            // Headless browser provides fast execution of tests as it doesnt open a real browser
            // Initialise WebDriver
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://trello.com/login");
        }

        public void quitWebDriverAfterTestRun()
        {
            // Quits the WebDriver after tests
            webDriver.Quit();
        }

        public void loginToTrello(string username, string password)
        {
            // Sleeps are used across different methods, as the loading of website sometimes takes more time.
            // But using sleep slows down the execution time for tests, so used it only when necessary.
            Thread.Sleep(5000);
            webDriver.FindElement(By.Id("username")).SendKeys(username);
            webDriver.FindElement(By.Id("login-submit")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.Id("password")).SendKeys(password);
            webDriver.FindElement(By.Id("login-submit")).Click();
        }
        public void createDefaultBoardInTrello(string boardName)
        {
            Thread.Sleep(8000);
            webDriver.FindElement(By.CssSelector("button[data-testid='header-create-menu-button']")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.CssSelector("button[data-testid='header-create-board-button']")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.CssSelector("input[data-testid='create-board-title-input']")).SendKeys(boardName);
            webDriver.FindElement(By.CssSelector("button[data-testid='create-board-submit-button']")).Click();
        }
       public void assertTheCreatedBoardName(string boardName)
        {
            Thread.Sleep(5000);
            Assert.IsTrue(webDriver.PageSource.Contains(boardName));
        }
        public void createTemplateBoardInTrello(string templateName, string boardName)
        {
            Thread.Sleep(8000);
            webDriver.FindElement(By.CssSelector("button[data-testid='header-create-menu-button']")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.CssSelector("button[data-testid='header-create-board-from-template-button']")).Click();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//*[text()='" + templateName + "']")).Click();
            Thread.Sleep(3000);

            webDriver.FindElement(By.CssSelector("input[data-testid='create-board-title-input']")).SendKeys(" " + boardName);
            Thread.Sleep(3000);

            webDriver.FindElement(By.CssSelector("button[data-testid='create-board-submit-button']")).Click();
        }
        public void deleteTheTrelloBoard()
        {
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/div[1]/div[1]/div/span[2]/button[2]/span/span")).Click();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/div[2]/div/div/div/div[2]/div/ul/li[17]/div/div/button")).Click();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//*[@id=\"chrome-container\"]/div[4]/div/div[2]/div/div/div/input")).Click();
        }
    }
}
