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
    public class LanguagePage : CommonDriver
    {
        public static IWebElement languageTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        public static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        public static IWebElement LanguageTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        public static IWebElement languageLevelDropdown => driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
        public static IWebElement fluentOption => driver.FindElement(By.XPath("//option[@value='Fluent']"));
        public static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement actualLanguage => driver.FindElement(By.XPath("//td[1]"));
        public static IWebElement actualLevel => driver.FindElement(By.XPath("//td[2]"));
        public static IWebElement editTab => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        public static IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        public static IWebElement deleteTab => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        public static IWebElement Deletedalerttext => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        public void AddLanguage(IWebDriver driver)
        {
            languageTab.Click();
            // click on add new button 
            addNewButton.Click();
           
            //Identify language textbox and enter valid details
            LanguageTextbox.SendKeys("English");


            //Identify language level dropdown and choose one
            languageLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='Fluent']", 3);

            fluentOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            // Click on add button
            addButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 3);
        }
        public string GetActualLanguage(IWebDriver driver)
        {
            return actualLanguage.Text;
        }
        public string GetLanguageLevel(IWebDriver driver)
        {
            return actualLevel.Text;
        }
        public void UpdateLanguage(IWebDriver driver, string Language, string Level)
        {
            //Identify language tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 1);
            languageTab.Click();

            //Identify edit symbol and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 2);
            editTab.Click();
       
            // Identify language textbox and enter valid details
            LanguageTextbox.Clear();
            LanguageTextbox.SendKeys(Language);

            //select the language level dropdown list
            var languageLevel = driver.FindElement(By.Name("level"));
            var selectElement = new SelectElement(languageLevel);
            selectElement.SelectByValue(Level);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]", 3);

            // Click on update button
            updateButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 2);
            Wait.WaitToBeClickable(driver, "XPath", "//td[2]", 2);

        }
        public string GetUpdatedLanguage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//td[1]", 2);
            return actualLanguage.Text;
        }
        public string GetUpdatedLevel(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//td[2]", 2);
            return actualLevel.Text;
        }

        public void DeleteLanguage(IWebDriver driver)
        {
            //Identify language tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 1);
            languageTab.Click();

            //Identify delete button and click on it
            deleteTab.Click();
           
        }
        public string GetDeletedLanguage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 3);
            return Deletedalerttext.Text;
        }
    }
}
