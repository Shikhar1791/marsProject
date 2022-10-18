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

namespace MarsQA.Pages
{
    public class LanguagePage
    {
        public void AddLanguage(IWebDriver driver)
        {
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            languageTab.Click();
            // click on add new button 
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            //Identify language textbox and enter valid details
            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguageTextbox.SendKeys("English");


            //Identify language level dropdown and choose one
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            languageLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='Fluent']", 3);

            IWebElement fluentOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
            fluentOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            // Click on add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(2000);
        }
        public string GetActualLanguage(IWebDriver driver)
        {
            IWebElement newLanguage = driver.FindElement(By.XPath("//td[1]"));
            return newLanguage.Text;
        }
        public string GetLanguageLevel(IWebDriver driver)
        {
            IWebElement languageLevel = driver.FindElement(By.XPath("//td[2]"));
            return languageLevel.Text;
        }
        public void UpdateLanguage(IWebDriver driver, string Language, string Level)
        {
            //Identify language tab and click on it
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            languageTab.Click();

            //Identify edit symbol and click on it
            IWebElement editTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editTab.Click();
            Thread.Sleep(2000);

            // Identify language textbox and enter valid details
            IWebElement addLanguageTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguageTextbox.Clear();
            addLanguageTextbox.SendKeys(Language);

            //select the language level dropdown list
            var languageLevel = driver.FindElement(By.Name("level"));
            var selectElement = new SelectElement(languageLevel);
            selectElement.SelectByValue(Level);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]", 3);

            // Click on update button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(2000);

        }
        public string GetUpdatedLanguage(IWebDriver driver)
        {
            IWebElement UpdatedLanguage = driver.FindElement(By.XPath("//td[1]"));
            return UpdatedLanguage.Text;
        }
        public string GetUpdatedLevel(IWebDriver driver)
        {
            IWebElement UpdatedLevel = driver.FindElement(By.XPath("//td[2]"));
            return UpdatedLevel.Text;
        }

        public void DeleteLanguage(IWebDriver driver)
        {
            //Identify language tab and click on it
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            languageTab.Click();

            //Identify delete button and click on it
            IWebElement deleteTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteTab.Click();
            Thread.Sleep(2000);


        }
        public string GetDeletedLanguage(IWebDriver driver)
        {
            IWebElement Deletedalerttext = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            return Deletedalerttext.Text;
        }
    }
}
