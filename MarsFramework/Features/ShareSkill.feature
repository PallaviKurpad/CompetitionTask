Feature: ShareSkill

As a seller
I want to add my skills in the portal for buyers to see

@tag1
Scenario: Add Skill
	Given I am on the Share Skill page
	When I enter valid Title
	And I enter valid dates
	And I enter valid values in all other fields
	And I click on Save button
	Then The record should be created successfully

Scenario: Add Skill with a Title too long 
	Given I am on the Share Skill page
	When I enter a Title that is too long
	And I enter valid dates
	And I enter valid values in all other fields
	And I click on Save button
	Then The record should be created with truncated Title

Scenario: Add Skill with Start Date after End Date
	Given I am on the Share Skill page
	When I enter valid Title
	And I enter Start Date after End Date
	And I enter valid values in all other fields
	And I click on Save button
	Then The record should not be created



