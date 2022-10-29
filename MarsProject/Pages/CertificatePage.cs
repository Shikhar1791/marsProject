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
using System.Timers;

namespace MarsQA.Pages
{
    public class CertificatePage : CommonDriver
    {
        public static IWebElement certificateTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        public static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        public static IWebElement CertificateTextbox => driver.FindElement(By.XPath("//input[@class='certification-award capitalize']"));
        public static IWebElement CertifiedfromTextbox => driver.FindElement(By.XPath("//input[@class='received-from capitalize']"));
        public static IWebElement certificateYearDropdown => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
        public static IWebElement yearOption => driver.FindElement(By.XPath("//option[@value='2016']"));
        public static IWebElement addButton => driver.FindElement(By.XPath("//input[@class='ui teal button ']"));
        public static IWebElement actualCertificate => driver.FindElement(By.XPath("//td[1]"));
        public static IWebElement actualCertificationFrom => driver.FindElement(By.XPath("//td[2]"));
        public static IWebElement actualCertificationYear => driver.FindElement(By.XPath("//td[3]"));
        public static IWebElement editTab => driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
        public static IWebElement updateButton => driver.FindElement(By.XPath("//input[@class='ui teal button']"));
        public static IWebElement deleteTab => driver.FindElement(By.XPath("//span/i[@class='remove icon']"));
        public static IWebElement Deletedalerttext => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        public void AddCertificate(IWebDriver driver)
        {
            // Identify Certifications tab and click on it
            certificateTab.Click();
            // click on add new button 
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
            addNewButton.Click();

            //Identify certificate textbox and enter valid details
            CertificateTextbox.SendKeys("CAST");

            //Identify certifiedfrom textbox and enter valid details
            CertifiedfromTextbox.SendKeys("Adobe");


            //Identify certificate year dropdown and choose one
            certificateYearDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//option[@value='2016']", 3);

            yearOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@class='ui teal button ']", 3);

            // Click on add button
            addButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 3);

        }
        public string GetActualCertificate(IWebDriver driver)
        {
            return actualCertificate.Text;
        }
        public string GetActualCertificationFrom(IWebDriver driver)
        {
            return actualCertificationFrom.Text;
        }
        public string GetActualCertificationYear(IWebDriver driver)
        {
            return actualCertificationYear.Text;
        }

        public void UpdateCertificate(IWebDriver driver, string Certificate, string From ,string Year)
        {

            // Identify Certifications tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 2);
            certificateTab.Click();

            //Identify edit symbol and click on it
            editTab.Click();
            
            // Identify certificate textbox and enter valid details
            CertificateTextbox.Clear();
            CertificateTextbox.SendKeys(Certificate);

            // Identify certifiedfrom textbox and enter valid details
            CertifiedfromTextbox.Clear();
            CertifiedfromTextbox.SendKeys(From);

            //select the Certification year dropdown list
            var certificationYear = driver.FindElement(By.Name("certificationYear"));
            var selectElement = new SelectElement(certificationYear);
            selectElement.SelectByValue(Year);

            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 3);

            // Click on update button
            updateButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//td[1]", 2);
            Wait.WaitToBeClickable(driver, "XPath", "//td[2]", 2);

        }
        public string GetUpdatedCertificate(IWebDriver driver)
        {
            return actualCertificate.Text;
        }
        public string GetUpdatedCertificationFrom(IWebDriver driver)
        {
            return actualCertificationFrom.Text;
        }

        public string GetUpdatedCertificationYear(IWebDriver driver)
        {
            return actualCertificationYear.Text;
        }

        public void DeleteCertification(IWebDriver driver)
        {
            // Identify Certifications tab and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 3);
            certificateTab.Click();

            //Identify delete button and click on it
            deleteTab.Click();
           


        }
        public string GetDeletedCertificate(IWebDriver driver)
        {
            return Deletedalerttext.Text;
        }


    }
}
