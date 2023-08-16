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
    internal class ChatRoom
    {
        IWebDriver driver = Global.GlobalDefinitions.driver;

        public ChatRoom()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "chatTextBox")]
        private IWebElement messageTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "btnSend")]
        private IWebElement sendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div/div[2]/div/div/span/div[last()]/div/div/span")]
        private IWebElement message { get; set; }

        By elementLocator;

        internal void EnterMessage(String message)
        {
            elementLocator = By.Id("chatTextBox");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            messageTextbox.SendKeys(message);
        }

        internal void SendMessage()
        {
            sendButton.Click();
        }

        internal void ValidateMessage(String sentMessage)
        {
            elementLocator = By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div/div/span/div[last()]/div/div/span");
            GlobalDefinitions.WaitForElement(driver, elementLocator, 5);

            String seenMessage = message.Text;

            if (seenMessage == sentMessage)
            {
                Assert.Pass("Message successfully sent");
            }
            else
            {
                Assert.Fail("Message not sent");
            }
        }

    }
}
