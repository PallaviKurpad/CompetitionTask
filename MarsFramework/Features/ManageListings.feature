Feature: ManageListings

A short summary of the feature

Scenario: Edit Skill with valid data
	Given I am on Manage Listings page
	When I click on Edit option for an existing record
	And I update existing values with valid data
	And I click on Save button
	Then The record should be updated successfully

Scenario: Edit Skill with invalid data
	Given I am on Manage Listings page
	When I click on Edit option for an existing record
	And I update existing values with valid data
	And I try to upload an invalid file type for Work Samples
	Then The file upload should not be allowed

Scenario: View Skill and Chat with seller
	Given I am on Manage Listings page
	When I click on View option for an existing record
	And I click on Chat button
	And I type a message in the chatbox
	And I click on Send button
	Then The message should be sent to the seller


Scenario: Delete Skill
	Given I am on the Share Skill page
	When I enter valid Title for delete
	And I enter valid dates
	And I enter valid values in all other fields
	And I click on Save button
	And I click on Delete option for an existing record
	Then The record should be deleted successfully
