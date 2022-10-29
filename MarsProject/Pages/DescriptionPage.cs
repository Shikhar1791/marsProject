using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA.Pages
{
    public class DescriptionPage : CommonDriver
    {
        public static IWebElement descriptionEditButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span"));
        public static IWebElement descriptionTextarea => driver.FindElement(By.Name("value"));
        public static IWebElement saveButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        public static IWebElement createdDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));

        public void AddDescription(IWebDriver driver, string description)
        {

            // Identify description edit button and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span", 2);
            descriptionEditButton.Click();
            
            // Identify description textarea and enter valid details
            descriptionTextarea.Clear();
            descriptionTextarea.SendKeys(description);

            //Click on save Button
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 2);

        }
        
        public string GetProfileDescription(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 2);
            return createdDescription.Text;
        }


        
        

        
    }
    
}
