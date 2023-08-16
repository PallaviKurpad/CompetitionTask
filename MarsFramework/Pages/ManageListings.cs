using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        IWebDriver driver = Global.GlobalDefinitions.driver;
        public ManageListings()
        {
            PageFactory.InitElements(driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='skill-title']")]
        private IWebElement skillTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement skillDescription { get; set; }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]")]
        private IWebElement ManageListingsTab { get; set; }

        By elementLocator;

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");


        }

        internal void View()
        {
            elementLocator = By.XPath("(//i[@class='eye icon'])[1]");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            view.Click();
        }

        internal void Delete()
        {
            elementLocator = By.XPath("(//i[@class='remove icon'])[1]");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            delete.Click();

            IWebElement yesButton = clickActionsButton.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            yesButton.Click();
        }

        internal void Edit()
        {
            elementLocator = By.XPath("(//i[@class='outline write icon'])[1]");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            edit.Click();
        }

        internal void ClickActionsButton()
        {

        }

        internal void GoToManageListings()
        {
            elementLocator = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            ManageListingsTab.Click();
        }

        internal void ValidateEditShareSkill(String ExpectedTitle, String ExpectedDescription)
        {
            View();

            String SeenTitle = skillTitle.Text;
            String SeenDescription = skillDescription.Text;

            if (SeenTitle == ExpectedTitle && SeenDescription == ExpectedDescription)
            {
                Assert.Pass("Share Skill updated successfully");
            }
            else
            {
                Assert.Fail("Share Skill not updated");
            }
        }

        
    }
}
