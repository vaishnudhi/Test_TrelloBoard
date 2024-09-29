
Feature: Creating Trello Board using Trello Web UI

Scenario Outline: The User creates a default board in Trello 

Given the user is logged into Trello board with "<Username>" and "<Password>"
When the user creates a new default board with name as "<BoardName>"
Then the user should see the new board on the Trello dashboard with name "<BoardName>"

# Here the delete board is included in the scenario as in the free trial of trello, only limited number of board creation is possible
Then Delete the created board in order to use the Trello Free Trial


Examples: 

| Username               | Password      | BoardName   |
| vaishnudhi96@gmail.com | mytrelloboard | TestBoard_1 |
| vaishnudhi96@gmail.com | mytrelloboard | TestBoard_2 |


Scenario Outline: The User creates a new board in Trello based with the pre-defined template

Given the user is logged into Trello board with "<Username>" and "<Password>"
When the user creates a new board with the template named "<TemplateName>" and board named "<BoardName>"
Then the user should see the new board on the Trello dashboard with name "<BoardName>"

# Here the delete board is included in the scenario as in the free trial of trello, only limited number of board creation is possible
Then Delete the created board in order to use the Trello Free Trial

Examples: 

| Username               | Password      | BoardName        | TemplateName       |
| vaishnudhi96@gmail.com | mytrelloboard | TestAgileBoard_1 | Company Overview	 |
| vaishnudhi96@gmail.com | mytrelloboard | TestAgileBoard_2 | Kanban Template	 |

 # More number of scenarios can be added here with different values (For example to test the negative flows)