
Feature: Skills
	I want to add,update and delete skills to my profile details

Scenario: 2-1 Add Skills 
	Given I logged on Mars portal successfully
	When I add Skills on my profile
	Then The Skills should be added sucessfully

Scenario Outline: 2-2 Update Skills
	Given I logged on Mars portal successfully
	When I edit '<Skill>' and '<Level>' on existing skill record
	Then The record should have the updated '<Skill>' and '<Level>'
Examples: 
	| Skill | Level    |
	| Java  | Beginner |

Scenario: 2-3 Delete skills on profile. 
	Given I logged on Mars portal successfully
	When I delete a Skill from an existing language record
	Then The Skill should be deleted sucessfully
