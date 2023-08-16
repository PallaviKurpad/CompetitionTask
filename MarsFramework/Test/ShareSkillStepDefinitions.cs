using MarsFramework.Global;
using MarsFramework.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework
{
    [Binding]
    public class ShareSkillStepDefinitions : GlobalDefinitions
    {
        ShareSkill shareSkill = new ShareSkill();
        String Title;
        String StartDate;
        String EndDate;

        [Given(@"I am on the Share Skill page")]
        public void GivenIAmOnTheShareSkillPage()
        {
            shareSkill.GoToShareSkill();
        }

        [When(@"I enter valid Title")]
        public void WhenIEnterValidTitle()
        {
            Title = "Web Development";
        }

        [When(@"I enter valid Title for delete")]
        public void WhenIEnterValidTitleForDelete()
        {
            Title = "Share skill for delete";
        }

        [When(@"I enter valid dates")]
        public void WhenIEnterValidDates()
        {
            StartDate = "30/10/2023";
            EndDate = "15/11/2023";
        }

        [When(@"I enter valid values in all other fields")]
        public void WhenIEnterValidValuesInAllOtherFields()
        {
            shareSkill.EnterShareSkill(Title, StartDate, EndDate);
        }

        [When(@"I click on Save button")]
        public void WhenIClickOnSaveButton()
        {
            shareSkill.SaveShareSkill();
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            shareSkill.ValidateShareSkill(Title);
        }

        [Then(@"The record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            shareSkill.ValidateDeleteShareSkill(Title);
        }

        [When(@"I enter a Title that is too long")]
        public void WhenIEnterATitleThatIsTooLong()
        {
            Title = "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
        }

        [Then(@"The record should be created with truncated Title")]
        public void ThenTheRecordShouldBeCreatedWithTruncatedTitle()
        {
            shareSkill.ValidateShareSkill(Title.Substring(0, 100));
        }

        [When(@"I enter Start Date after End Date")]
        public void WhenIEnterStartDateAfterEndDate()
        {
            StartDate = "30/11/2023";
            EndDate = "15/10/2023";
        }

        [Then(@"The record should not be created")]
        public void ThenTheRecordShouldNotBeCreated()
        {
            shareSkill.ValidateShareSkill(Title);   
        }
    }
}
