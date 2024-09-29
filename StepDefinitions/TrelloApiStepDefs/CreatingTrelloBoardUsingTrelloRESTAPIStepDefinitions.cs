using RestSharp;
using NUnit.Framework;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Test_TrelloBoard.StepDefinitions.TrelloApiStepDefs
{

    [Binding]
    public class CreatingTrelloBoardUsingTrelloRESTAPIStepDefinitions
    {
        private RestClient client;
        private RestResponse response;


        [Given(@"the user is authenticated to Trello API")]
        public void GivenTheUserIsAuthenticatedToTrelloAPI()
        {
            client = new RestClient("https://api.trello.com/1/");
        }

        [When(@"the user creates a new board with ""([^""]*)"" ""([^""]*)"" And ""([^""]*)""")]
        public void WhenTheUserCreatesANewBoard(string boardName, string apiKey, string apiToken)
        {
            var request = new RestRequest("boards", Method.Post);
            request.AddParameter("name", boardName);
            setApiKeyAndTokenInRequest(apiKey, apiToken, request);
            response = client.Execute(request);
        }

// This Method is shared across different scenarios as setting of APiKey and token is common for most scenarios
        private static void setApiKeyAndTokenInRequest(string apiKey, string apiToken, RestRequest request)
        {
            request.AddParameter("key", apiKey);
            request.AddParameter("token", apiToken);
        }

        [When(@"the user deletes the created board ""([^""]*)"" with ""([^""]*)"" And ""([^""]*)"" to save space")]
        public void WhenTheUserDeletesTheCreatedBoardWithAnd(string boardName, string apiKey, string apiToken)
        {
            dynamic jsonResponse = JObject.Parse(response.Content);
            var id = jsonResponse.idBoard;
            if (id == null)
            {
                id = jsonResponse.id;
            }
            var request = new RestRequest("boards/" + id, Method.Delete);
            setApiKeyAndTokenInRequest(apiKey, apiToken, request);
            response = client.Execute(request);
        }


        [Then(@"verify the created board has name ""([^""]*)""")]
        public void ThenVerifyTheCreatedBoard(string boardName)
        {
            Assert.IsTrue(response.Content.Contains(boardName));
        }

        [Then(@"the response from the api is ""([^""]*)""")]
        public void ThenTheResponseFromTheApiIs(HttpStatusCode status)
        {
            Assert.IsTrue(response.StatusCode == status);
        }

        [When(@"the user creates a list with name ""([^""]*)"" in the board with ""([^""]*)"" And ""([^""]*)""")]
        public void WhenTheUserCreatesAListWithNameInTheBoardWithAnd(string listName, string apiKey, string apiToken)
        {
            dynamic jsonResponse = JObject.Parse(response.Content);
            var id = jsonResponse.id;
            var request = new RestRequest("boards/" + id + "/lists", Method.Post);
            request.AddParameter("name", listName);
            setApiKeyAndTokenInRequest(apiKey, apiToken, request);
            response = client.Execute(request);
        }

        [Then(@"verify the created ""([^""]*)"" from the response")]
        public void ThenVerifyTheCreatedFromTheResponse(string listName)
        {
            dynamic jsonResponse = JObject.Parse(response.Content);
            var nameOfListFromResponse = jsonResponse.name;
            Assert.AreEqual(listName, nameOfListFromResponse.Value);
        }


    }
}