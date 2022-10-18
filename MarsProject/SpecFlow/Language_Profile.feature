Feature: Language
	I want to add,update and delete language to my profile details

Scenario: 1-1 Add language 
	Given I logged in Mars portal successfully
	When I add language on my profile
	Then The language should be added sucessfully

Scenario: 1-2 Update language 
	Given I logged in Mars portal successfully
	When I edit '<Language>' and '<Level>' on existing language record
	Then The record should have the edited '<Language>' and '<Level>'
Examples: 
	| Language | Level |
	| French   | Basic |

Scenario: 1-3 Delete language on profile. 
	Given I logged in Mars portal successfully
	When I delete a language from an existing language record
	Then The language should be deleted sucessfully
