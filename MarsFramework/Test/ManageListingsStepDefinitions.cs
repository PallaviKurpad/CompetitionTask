using MarsFramework.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsFramework
{
    [Binding]
    public class ManageListingsStepDefinitions
    {
        ManageListings manageListings = new ManageListings();
        ShareSkill shareSkill = new ShareSkill();
        ServiceDetail serviceDetail = new ServiceDetail();
        ChatRoom chatRoom = new ChatRoom();

        String title;
        String description;
        String message;

        [Given(@"I am on Manage Listings page")]
        public void GivenIAmOnManageListingsPage()
        {
            manageListings.GoToManageListings();
        }

        [When(@"I click on Edit option for an existing record")]
        public void WhenIClickOnEditOptionForAnExistingRecord()
        {
            manageListings.Edit();
        }

        [When(@"I update existing values with valid data")]
        public void WhenIUpdateExistingValuesWithValidData()
        {
            title = "Frontend Development";
            description = "ABC XYZ";
            shareSkill.EditShareSkill(title, description);
        }

        [Then(@"The record should be updated successfully")]
        public void ThenTheRecordShouldBeUpdatedSuccessfully()
        {
            manageListings.ValidateEditShareSkill(title, description);
        }

        [When(@"I click on Delete option for an existing record")]
        public void WhenIClickOnDeleteOptionForAnExistingRecord()
        {
            Thread.Sleep(2000);
            manageListings.Delete();
        }

        [When(@"I try to upload an invalid file type for Work Samples")]
        public void WhenITryToUploadAnInvalidFileTypeForWorkSamples()
        {
            shareSkill.UploadInvalidFileType();
        }

        [Then(@"The file upload should not be allowed")]
        public void ThenTheFileUploadShouldNotBeAllowed()
        {
            shareSkill.CheckErrorMessage();
        }

        [When(@"I click on View option for an existing record")]
        public void WhenIClickOnViewOptionForAnExistingRecord()
        {
            manageListings.View();
        }

        [When(@"I click on Chat button")]
        public void WhenIClickOnChatButton()
        {
            serviceDetail.GoToChatBox();
        }

        [When(@"I type a message in the chatbox")]
        public void WhenITypeAMessageInTheChatbox()
        {
            message = "Hello Seller";
            chatRoom.EnterMessage(message);
        }

        [When(@"I click on Send button")]
        public void WhenIClickOnSendButton()
        {
            chatRoom.SendMessage();
        }

        [Then(@"The message should be sent to the seller")]
        public void ThenTheMessageShouldBeSentToTheSeller()
        {
            chatRoom.ValidateMessage(message);
        }
    }
}
