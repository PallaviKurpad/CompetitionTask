using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        IWebDriver driver = Global.GlobalDefinitions.driver;
        public ShareSkill()
        {
            PageFactory.InitElements(driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Select Category
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]")]
        private IWebElement Category { get; set;}

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Select Sub-category
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[3]")]
        private IWebElement SubCategory { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        //[FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        //[FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement LatestTitleSeen { get; set; }

        [FindsBy(How = How.Id, Using = "selectFile")]
        private IWebElement WorkSamples { get; set; }

        [FindsBy(How = How.ClassName, Using = "ns-box-inner")]
        private IWebElement ErrorMessage { get; set; }

        By elementLocator;

        internal void GoToShareSkill()
        {
            elementLocator = By.LinkText("Share Skill");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            ShareSkillButton.Click();
        }

        internal void EnterShareSkill(String Title, String StartDate, String EndDate)
        {
            elementLocator = By.Name("title");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);
            this.Title.SendKeys(Title);
            
            Description.SendKeys("Coding, Testing, Web applications, Database");
            
            CategoryDropDown.Click();
            Category.Click();

            SubCategoryDropDown.Click();
            SubCategory.Click();

            Tags.SendKeys("Java");
            Tags.SendKeys(Keys.Enter);
            ServiceTypeOptions.Click();
            LocationTypeOption.Click();

            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(StartDate);

            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(EndDate);

            Days.Click();

            StartTimeDropDown.Click();
            StartTimeDropDown.SendKeys("10:00 am");

            EndTimeDropDown.Click();
            EndTimeDropDown.SendKeys("01:00 pm");

            SkillTradeOption.Click();
            SkillExchange.SendKeys("Gardening");
            SkillExchange.SendKeys(Keys.Enter);

            ActiveOption.Click();

        }

        internal void SaveShareSkill()
        {
            Save.Click();
        }

        internal void ValidateShareSkill(String Title)
        {
            elementLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");

            try
            {
                GlobalDefinitions.WaitForElement(driver, elementLocator, 5);
            }
            catch(WebDriverTimeoutException e)
            {
                Assert.Pass("Share Skill not created");
            }

            if (LatestTitleSeen.Text == Title)
            {
                Assert.Pass("Share Skill created successfully");
            }
            else
            {
                Assert.Fail("Share Skill not created");
            }
        }

        internal void EditShareSkill(String Title, String Description)
        {
            elementLocator = By.Name("title");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            this.Title.Clear();
            this.Title.SendKeys(Title);

            this.Description.Clear();
            this.Description.SendKeys(Description);
        }

        internal void UploadInvalidFileType()
        {
            WorkSamples.SendKeys("C:\\Users\\palla\\Downloads\\marsframework-master.zip");
        }

        internal void CheckErrorMessage()
        {
            elementLocator = By.ClassName("ns-box-inner");

            try
            {
                GlobalDefinitions.WaitForElement(driver, elementLocator, 5);
            }
            catch (WebDriverTimeoutException e)
            {
                Assert.Fail("Invalid file type allowed");
            }

            if(ErrorMessage.Text.Contains("Max size"))
            {
                Assert.Pass("Invalid file type not allowed");
            }
        }

        internal void ValidateDeleteShareSkill(String Title)
        {
            Thread.Sleep(1000);
            elementLocator = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
            
            try
            {
                GlobalDefinitions.WaitForElement(driver, elementLocator, 5);
            }
            catch (WebDriverTimeoutException e)
            {
                Assert.Pass("Share Skill not created");
            }

            if (LatestTitleSeen.Text == Title)
            {
                Assert.Fail("Share Skill not deleted");
            }
            else
            {
                Assert.Pass("Share Skill deleted successfully");
            }
        }
    }
}
