using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace MarsQA.Pages
{
    public class CertificatePage
    {
        public void AddCertificate(IWebDriver driver)
        {
            // Identify Certifications tab and click on it
            IWebElement certificateTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificateTab.Click();
            // click on add new button 
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
            addNewButton.Click();

            //Identify certificate textbox and enter valid details
            IWebElement addCertificateTextbox = driver.FindElement(By.XPath("//input[@class='certification-award capitalize']"));
            addCertificateTextbox.SendKeys("CAST");

            //Identify certifiedfrom textbox and enter valid details
            IWebElement addCertifiedfromTextbox = driver.FindElement(By.XPath("//input[@class='received-from capitalize']"));
            addCertifiedfromTextbox.SendKeys("Adobe");


            //Identify certificate year dropdown and choose one
            IWebElement certificateYearDropdown = driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            certificateYearDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='2016']", 3);

            IWebElement yearOption = driver.FindElement(By.XPath("//option[@value='2016']"));
            yearOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@class='ui teal button ']", 3);

            // Click on add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@class='ui teal button ']"));
            addButton.Click();
            Thread.Sleep(2000);
        }
        public string GetActualCertificate(IWebDriver driver)
        {
            IWebElement newCertificate = driver.FindElement(By.XPath("//td[1]"));
            return newCertificate.Text;
        }
        public string GetActualCertificationFrom(IWebDriver driver)
        {
            IWebElement certificationFrom = driver.FindElement(By.XPath("//td[2]"));
            return certificationFrom.Text;
        }
        public string GetActualCertificationYear(IWebDriver driver)
        {
            IWebElement certificationYear = driver.FindElement(By.XPath("//td[3]"));
            return certificationYear.Text;
        }

        public void UpdateCertificate(IWebDriver driver, string Certificate, string From ,string Year)
        {

            // Identify Certifications tab and click on it
            IWebElement certificateTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificateTab.Click();

            //Identify edit symbol and click on it
            IWebElement editTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
            editTab.Click();
            Thread.Sleep(2000);

            // Identify certificate textbox and enter valid details
            IWebElement updateCertificateTextbox = driver.FindElement(By.XPath("//input[@class='certification-award capitalize']"));
            updateCertificateTextbox.Clear();
            updateCertificateTextbox.SendKeys(Certificate);

            // Identify certifiedfrom textbox and enter valid details
            IWebElement updateCertifiedfromTextbox = driver.FindElement(By.XPath("//input[@class='received-from capitalize']"));
            updateCertifiedfromTextbox.Clear();
            updateCertifiedfromTextbox.SendKeys(From);

            //select the Certification year dropdown list
            var certificationYear = driver.FindElement(By.Name("certificationYear"));
            var selectElement = new SelectElement(certificationYear);
            selectElement.SelectByValue(Year);

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 3);

            // Click on update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@class='ui teal button']"));
            updateButton.Click();
            Thread.Sleep(2000);

        }
        public string GetUpdatedCertificate(IWebDriver driver)
        {
            IWebElement updatedCertificate = driver.FindElement(By.XPath("//td[1]"));
            return updatedCertificate.Text;
        }
        public string GetUpdatedCertificationFrom(IWebDriver driver)
        {
            IWebElement GetUpdatedCertificationFrom = driver.FindElement(By.XPath("//td[2]"));
            return GetUpdatedCertificationFrom.Text;
        }

        public string GetUpdatedCertificationYear(IWebDriver driver)
        {
            IWebElement GetUpdatedCertificationYear = driver.FindElement(By.XPath("//td[3]"));
            return GetUpdatedCertificationYear.Text;
        }

        public void DeleteCertification(IWebDriver driver)
        {
            // Identify Certifications tab and click on it
            IWebElement certificateTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificateTab.Click();

            //Identify delete button and click on it
            IWebElement deleteTab = driver.FindElement(By.XPath("//span/i[@class='remove icon']"));
            deleteTab.Click();
            Thread.Sleep(2000);


        }
        public string GetDeletedCertificate(IWebDriver driver)
        {
            IWebElement Deletedalerttext = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            return Deletedalerttext.Text;
        }


    }
}
