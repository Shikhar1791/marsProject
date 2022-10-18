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

namespace MarsQA.Pages
{
    public class DescriptionPage
    {
       
        public void AddDescription(IWebDriver driver, string description)
        {

            // Identify description edit button and click on it
            IWebElement descriptionEditButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span"));
            descriptionEditButton.Click();

            Thread.Sleep(2000);

            // Identify description textarea and enter valid details
            IWebElement descriptionTextarea = driver.FindElement(By.Name("value"));
            descriptionTextarea.Clear();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 2);

            descriptionTextarea.SendKeys(description);

            //Click on save Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")).Click();
            Thread.Sleep(2000);

            //Check if description is present in page
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            Thread.Sleep(1000);
        }
        
        public string GetProfileDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            return createdDescription.Text;
        }


        
        

        
    }
    
}
