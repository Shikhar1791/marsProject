using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA.Pages
{
  public class ProfilePage
    {
        public void GoToProfilePage(IWebDriver driver)
        {

            // Click on ProfileTab
            IWebElement ProfileTab = driver.FindElement(By.XPath("//*[@id=\'account-profile-section\']/div/section[1]/div/a[2]"));
            ProfileTab.Click();

            Thread.Sleep(1000);
        }

    }
}
