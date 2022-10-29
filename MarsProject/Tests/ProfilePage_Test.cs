using MarsQA.Pages;
using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MarsQA.Tests
{
    [TestFixture]
    public class ProfilePage_Test : CommonDriver
    {
        //Home page object initialization and definition
        ProfilePage profilePageObj = new ProfilePage();
        //Profile page object initialization and definition
        DescriptionPage descriptionPageObj = new DescriptionPage();
        LanguagePage languagePageObj = new LanguagePage();

        [Test, Order(1), Description("Check if user able to Add description on profile page")]
        public void AddDescription_Test(IWebDriver driver, string description)

        {

            profilePageObj.GoToProfilePage();
            descriptionPageObj.AddDescription(driver, description);

        }

        [Test, Order(2), Description("Check if user able to Add Language on profile page")]
        public void AddLanguage_Test()
        {

            profilePageObj.GoToProfilePage();
            languagePageObj.AddLanguage(driver);

        }


        [Test, Order(3), Description("Check if user able to Update Language on profile page")]
        public void UpdateLanguage_Test(IWebDriver driver, string Language, string Level)
        {

            profilePageObj.GoToProfilePage();
            languagePageObj.UpdateLanguage(driver, Language, Level);

        }

        [Test, Order(4), Description("Check if user able to Delete Language on profile page")]
        public void DeleteLanguage_Test()
        {

            profilePageObj.GoToProfilePage();
            languagePageObj.DeleteLanguage(driver);

        }

        /*[Test, Order(3)]
        public void ShareSkill_Test()
        {
            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToProfilePage(driver);

            SellerListingPage sellerListingPageObj = new SellerListingPage();
            sellerListingPageObj.ShareSkillsSteps(driver);
        }


        /*[Test, Order(4)]
        public void EditListing_Test()
        {
            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToProfilePage(driver);

            SellerListingPage sellerListingPageObj = new SellerListingPage();
            sellerListingPageObj.EditListing(driver);
        }

        [Test, Order(4)]
        public void ViewProfile_Test()
        {
            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToProfilePage(driver);

            SellerListingPage sellerListingPageObj = new SellerListingPage();
            sellerListingPageObj.ViewListing(driver);
        }


        /* [Test,Order(4)]
         public void AddSkill_Test()
         {
             //Home page object initialization and definition
             HomePage homePageObj = new HomePage();
             homePageObj.GoToProfilePage(driver);

             //Profile page object initialization and definition
             ProfilePage profilePageObj = new ProfilePage();
             profilePageObj.AddSkill(driver);

         }*/

    }
}
