Feature: Certifications
	As a seller
	I want to add, delete and update Certificate in my profile.


@AddCertification
Scenario Outline:3-1 Add certificate 
	Given I logged onto Mars portal successfully
	When I add certification to my profile
	Then New Certificate details will be added



Scenario Outline:3-2  Update Certificate
	Given I logged onto Mars portal successfully
	When I update '<Certificate>' , '<From>' , and '<Year>'
	Then The Certificate should should have edited'<Certificate>', '<From>' and '<Year>' 

Examples: 
	| Certificate | From   | Year | 									  
	| ISTQB       | Google | 2021 | 


Scenario Outline: 3-3 Delete Certificate 
	Given I logged onto Mars portal successfully
	When I delete Certification from Certification record
	Then The Certifications record should be deleted succesfully


