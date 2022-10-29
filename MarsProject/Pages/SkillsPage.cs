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
    public class SkillsPage : CommonDriver
    {
        public static IWebElement skillsTab => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public static IWebElement skillsTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public static IWebElement skillsLevelDropdown => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
        public static IWebElement expertOption => driver.FindElement(By.XPath("//option[@value='Expert']"));
        public static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement actualSkills => driver.FindElement(By.XPath("//td[1]"));
        public static IWebElement actualSkillsLevel => driver.FindElement(By.XPath("//td[2]"));
        public static IWebElement editTab => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        public static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public static IWebElement deleteTab => driver.FindElement(By.XPath("//span/i[@class='remove icon']"));
        public static IWebElement Deletedalerttext => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        public void AddSkills(IWebDriver driver)
        {
            skillsTab.Click();
            // click on add new button 
            addNewButton.Click();

            //Identify skills textbox and enter valid details
            skillsTextbox.SendKeys("Selenium");

            //Identify skills level dropdown and choose one
            skillsLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='Expert']", 3);

            expertOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            // Click on add button
            addButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 3);
        }
        public string GetActualSkills(IWebDriver driver)
        {
            return actualSkills.Text;
        }
        public string GetSkillsLevel(IWebDriver driver)
        {
            return actualSkillsLevel.Text;
        }

        public void UpdateSkills(IWebDriver driver, string Skill, string Level)
        {
            //Identify skills tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 2);
            skillsTab.Click();

            //Identify edit symbol and click on it
            editTab.Click();
            
            // Identify skills textbox and enter valid details
            Wait.WaitToBeClickable(driver, "XPath", "//input[@placeholder='Add Skill']", 2);
            skillsTextbox.Clear();
            skillsTextbox.SendKeys(Skill);

            //select the language level dropdown list
            var skillsLevel = driver.FindElement(By.Name("level"));
            var selectElement = new SelectElement(skillsLevel);
            selectElement.SelectByValue(Level);

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 3);

            // Click on update button
            updateButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 2);
            Wait.WaitToBeClickable(driver, "XPath", "//td[2]", 2);

        }
        public string GetUpdatedSkills(IWebDriver driver)
        {
            return actualSkills.Text;
        }
        public string GetUpdatedLevel(IWebDriver driver)
        {
            return actualSkillsLevel.Text;
        }

        public void Deleteskills(IWebDriver driver)
        {
            //Identify skills tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 2);
            skillsTab.Click();

            //Identify delete button and click on it
            deleteTab.Click();
            
        }
        public string GetDeletedSkills(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "/html/body/div[1]/div", 3);
            return Deletedalerttext.Text;
        }





    }


    
}
