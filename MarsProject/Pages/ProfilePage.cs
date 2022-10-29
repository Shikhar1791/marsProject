using MarsQA.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA.Pages
{
  public class ProfilePage : CommonDriver


    {
     
        public void GoToProfilePage()
        {

            // Click on ProfileTab
            Wait.WaitToBeClickable(driver, "XPath", "//section/div/a[@href='/Account/Profile']", 3);
            IWebElement ProfileTab = driver.FindElement(By.XPath("//section/div/a[@href='/Account/Profile']"));
            ProfileTab.Click();

            //Thread.Sleep(1000);
        }

    }
}
