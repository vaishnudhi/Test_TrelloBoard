
Feature: Creating Trello Board using Trello REST API


Scenario Outline: The User creates a board in Trello using Trello API

Given the user is authenticated to Trello API
When the user creates a new board with "<BoardName>" "<ApiKey>" And "<ApiToken>"
Then verify the created board has name "<BoardName>"
And the response from the api is "<ResponseStatus>"

# Here the delete board is included in the scenario as in the free trial of trello, only limited number of board creation is possible
When the user deletes the created board "<BoardName>" with "<ApiKey>" And "<ApiToken>" to save space
Then the response from the api is "<ResponseStatus>"


Examples:

| ApiKey                           | ApiToken                                                                     | BoardName | ResponseStatus  |
| dc862a8da5d7479b1c8f91522ba74dc3 | ATTA15f24561d4963629b0388deae3a7db5bfa3ea854a8b03233c80fb202517bfa71870138EB | Test Board | OK				|
# more number of scenarios can be added here with different ApiKey, token, boardName and Negative flows in Response Status


Scenario Outline: The User try to add the list to the existing trello board using Trello API

Given the user is authenticated to Trello API
When the user creates a new board with "<BoardName>" "<ApiKey>" And "<ApiToken>"
Then the response from the api is "<ResponseStatus>"
When the user creates a list with name "<listName>" in the board with "<ApiKey>" And "<ApiToken>"
Then the response from the api is "<ResponseStatus>"
And verify the created "<listName>" from the response

# Here the delete board is included in the scenario as in the free trial of trello, only limited number of board creation is possible
When the user deletes the created board "<BoardName>" with "<ApiKey>" And "<ApiToken>" to save space
Then the response from the api is "<ResponseStatus>"


Examples:

| listName | ApiKey                           | ApiToken                                                                     | BoardName  | ResponseStatus |
| testList | dc862a8da5d7479b1c8f91522ba74dc3 | ATTA15f24561d4963629b0388deae3a7db5bfa3ea854a8b03233c80fb202517bfa71870138EB | Test Board | OK             |
# more number of scenarios can be added here with different ApiKey, token, boardName and Negative flows in Response Status




# In between Scenario one and two, I have tried to reuse already written code (For example, Authentication, board creation and deletion)