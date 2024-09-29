
Trello Board Automation Testing
---------------------
In this project, The creation of a board in trello is automated in 2 ways. one by using webUi of the Trello, the second way is by using the Api calls offered by Trello

1. Automation testing using the WebUi of Trello :
---------------------
	Tools and Framework Used :
		Specflow, Selenium, C# and Visual Studio
	- SpecFlow tests are written using Gherkin, which allows you to write test cases using natural languages.
	- Selenium, Primarily used for automating web applications for testing purposes.
	- Visual Studio is an IDE used to write this project
	- The authentication is done by signing up in the trello portal.

2. Automation testing using the Api of Trello :
---------------------
	Tools and Framework Used :
		Specflow, RestSharp, C# and Visual Studio
	- SpecFlow tests are written using Gherkin, which allows you to write test cases using natural languages.
	- Visual Studio is an IDE used to write this project
	- RestSharp, Simple REST and HTTP API Client for .NET
	- The authentication of the API is done using the Api token and Api key


How to Build and Run :
---------------------
	1. Clone this repository into your local repository.
	2. Open it the IDE which supports .Net or C# (Preferrably Visual Studio)
	3. Build the project using the Build option in the IDE.
	4. Go to the "Test Explorer" tab, and Run the tests.


As a trial branch, only limited number of scenarios were covered in this project. 
Some of other test cases I would like to test are as follows,

User Acceptance testing
-----------------------

While creating the board-

1) Verify If the user can create a new board with a valid name including special characters and empty spaces.
2) Test that the user cannot create a new board when the user gives an invalid board name(e.g., empty name).

While creating the list-

1) Verify that the user can create a new list within the created board with a valid name including special characters.
2) Test that the user cannot create a list within the board when the user gives an invalid board name(e.g., empty name).
3) Test that the user can create the maximum number of lists allowed.

While adding the card-

1) Verify that the user can create a new card within a list.
2) Test that the user cannot add a card without entering a title or any links or when the card is empty.
3) Check if the cards can accept attachments, hyperlinks, pictures, descriptions, checklists, etc.

While navigating between boards,

1) Verify that users can switch between multiple boards.

Functional Testing
-----------------

While Dragging and Dropping of lists and card-

1) Verify that the user can drag and drop the created lists back and forth.
2) Verify that the user can drag and drop the created cards between the various lists.
3) Verify that the user can reorder the created cards  within the same list.
4) Verify that the contents of the cards remain unchanged after reordering.

While editing the contents of the card-

1) Verify that the user can edit the card title, description, checklists,labels, due dates, etc.

While adding checklists-

1) Verify that a user can add and remove checklists to a card.
2) Test if the checklist can be marked and unmarked.

While adding labels and filters-

1) Verify that users can add or remove labels from a card.

While adding due dates and reminders-

1) Test that the user will be able to set due dates for a card.
2) Verify that reminders/notifications are sent correctly as per the due date.

While adding comments-

1) Verify that users can add comments to cards.
2) Test that the user can edit and delete the comments


Data Integrity testing
---------------------

While deleting the board-

1) Verify that the user can delete a board which is already created
2) Test whether deleted boards are completely removed or archived .
3) Ensure that the deletion process has a confirmation step to avoid accidental deletion.


While logging in-

1) Verify that the user can log in only using valid credentials.
2) Test that users cannot access the board without logging in.

While logging out-

1) Verify that the user is successfully logged out.

While staying inactive in screen-

1) Verify that user sessions expire after a period of inactivity.



Test Report Generation
--------------------------------

I would generate test reports for all the SpecFlow test scenarios by integrating a Test report generation tool such as Specflow+LivingDoc.

Ater running the tests the reports can be generated from LivingDoc which results in a HTML report where we can observe the following

 1) Status of the scenarios(passed or failed) 

 2) Error messages if any
