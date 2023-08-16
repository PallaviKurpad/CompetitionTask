using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ServiceDetail
    {
        IWebDriver driver = Global.GlobalDefinitions.driver;

        public ServiceDetail() 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Chat")]
        private IWebElement chatButton { get; set; }

        By elementLocator;

        internal void GoToChatBox()
        {
            elementLocator = By.LinkText("Chat");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            chatButton.Click();
        }

    }
}
