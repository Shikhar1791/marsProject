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
    public class SkillsPage
    {
        public void AddSkills(IWebDriver driver)
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();
            // click on add new button 
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@class='ui teal button']"));
            addNewButton.Click();

            //Identify skills textbox and enter valid details
            IWebElement addSkillsTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkillsTextbox.SendKeys("Selenium");


            //Identify skills level dropdown and choose one
            IWebElement skillsLevelDropdown = driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            skillsLevelDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='Expert']", 3);

            IWebElement expertOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
            expertOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 3);

            // Click on add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(2000);
        }
        public string GetActualSkills(IWebDriver driver)
        {
            IWebElement newSkills = driver.FindElement(By.XPath("//td[1]"));
            return newSkills.Text;
        }
        public string GetSkillsLevel(IWebDriver driver)
        {
            IWebElement skillsLevel = driver.FindElement(By.XPath("//td[2]"));
            return skillsLevel.Text;
        }

        public void UpdateSkills(IWebDriver driver, string Skill, string Level)
        {
            //Identify skills tab and click on it
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            //Identify edit symbol and click on it
            IWebElement editTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editTab.Click();
            Thread.Sleep(2000);

            // Identify skills textbox and enter valid details
            IWebElement addSkilsTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkilsTextbox.Clear();
            addSkilsTextbox.SendKeys(Skill);

            //select the language level dropdown list
            var skillsLevel = driver.FindElement(By.Name("level"));
            var selectElement = new SelectElement(skillsLevel);
            selectElement.SelectByValue(Level);

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 3);

            // Click on update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(2000);

        }
        public string GetUpdatedSkills(IWebDriver driver)
        {
            IWebElement updatedSkills = driver.FindElement(By.XPath("//td[1]"));
            return updatedSkills.Text;
        }
        public string GetUpdatedLevel(IWebDriver driver)
        {
            IWebElement updatedLevel = driver.FindElement(By.XPath("//td[2]"));
            return updatedLevel.Text;
        }

        public void Deleteskills(IWebDriver driver)
        {
            //Identify skills tab and click on it
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            //Identify delete button and click on it
            IWebElement deleteTab = driver.FindElement(By.XPath("//span/i[@class='remove icon']"));
            deleteTab.Click();
            Thread.Sleep(2000);


        }
        public string GetDeletedSkills(IWebDriver driver)
        {
            IWebElement Deletedalerttext = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            return Deletedalerttext.Text;
        }





    }


    
}
