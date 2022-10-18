Feature: Description

As a Seller in Mars portal
I would like to add and update my Description

Scenario Outline: add description to my profile
	Given I logged into Mars portal successfully
	When I navigate to Profile page
	And I add new '<description>'
	Then the '<description>' should be created successfully

	Examples: 
	| description     |
	| Software Tester |
	| Test Analyst    |

