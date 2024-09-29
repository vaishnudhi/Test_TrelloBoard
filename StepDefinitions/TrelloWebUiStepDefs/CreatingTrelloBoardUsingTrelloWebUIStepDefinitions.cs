using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Test_TrelloBoard.Business;

namespace Test_TrelloBoard.StepDefinitions.TrelloWebUiStepDefs
{
    [Binding]
    public class CreatingTrelloBoardUsingTrelloWebUIStepDefinitions
    {
        private TrelloObject trelloObject = new TrelloObject();

        [BeforeScenario]
        public void InitMethod()
        {
            trelloObject.initiatialiseWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            trelloObject.quitWebDriverAfterTestRun();
        }
     
        [Given(@"the user is logged into Trello board with ""([^""]*)"" and ""([^""]*)""")]
        public void GivenTheUserIsLoggedIntoTrelloBoardWithAnd(string username, string password)
        {
            trelloObject.loginToTrello(username, password);
        }

        [When(@"the user creates a new default board with name as ""([^""]*)""")]
        public void WhenTheUserCreatesAdefaultBoard(string boardName)
        {
            trelloObject.createDefaultBoardInTrello(boardName);
        }      

        [Then(@"the user should see the new board on the Trello dashboard with name ""([^""]*)""")]
        public void ThenTheUserShouldSeeTheNewBoardOnMyTrelloDashboard(string boardName)
        {
            trelloObject.assertTheCreatedBoardName(boardName);
        }

        [When(@"the user creates a new board with the template named ""([^""]*)"" and board named ""([^""]*)""")]
        public void WhenTheUserCreatesATemplateBoard(string templateName, string boardName)
        {
            trelloObject.createTemplateBoardInTrello(templateName, boardName);
        }

        [Then(@"Delete the created board in order to use the Trello Free Trial")]
        public void ThenDeleteTheCreatedBoardInOrderToUseTheTrelloFreeTrial()
        {
            trelloObject.deleteTheTrelloBoard();
        }

      
    }
}
