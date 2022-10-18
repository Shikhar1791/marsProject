using System;
using MarsQA.Pages;
using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        LanguagePage languagePageObj = new LanguagePage();
        ProfilePage profilePageObj = new ProfilePage();
        LoginPage loginPageObj = new LoginPage();

        [Given(@"I logged in Mars portal successfully")]
        public void GivenILoggedOntoMarsPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();

            // Login page Object login and initialization and defination
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I add language on my profile")]
        public void WhenIAddLanguageOnMyProfile()
        {
            profilePageObj.GoToProfilePage(driver);
            languagePageObj.AddLanguage(driver);
        }

        [Then(@"The language should be added sucessfully")]
        public void ThenTheLanguageShouldBeAddedSucessfully()
        {
            string language = languagePageObj.GetActualLanguage(driver);
            string level = languagePageObj.GetLanguageLevel(driver);

            Assert.That(language == "English", "Actual language and expected language do not match");
            Assert.That(level == "Fluent", "Actual level and expected level do not match"); ;
        }

        [When(@"I edit '([^']*)' and '([^']*)' on existing language record")]
        public void WhenIEditAndOnExistingLanguageRecord(string Language, string Level)
        {
            languagePageObj.UpdateLanguage(driver, Language, Level);
        }

        [Then(@"The record should have the edited '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheEditedAnd(string Language, string Level)
        {
            string updatedlanguage = languagePageObj.GetUpdatedLanguage(driver);
            string updatedlevel = languagePageObj.GetUpdatedLevel(driver);

            Assert.That(updatedlanguage == Language, "Updated language and expected language do not match");
            Assert.That(updatedlevel == Level, "Actual level and expected level do not match"); ;
        }



        [When(@"I delete a language from an existing language record")]
        public void WhenIDeleteALanguageFromAnExistingLanguageRecord()
        {
            languagePageObj.DeleteLanguage(driver);
        }

        [Then(@"The language should be deleted sucessfully")]
        public void ThenTheLanguageShouldBeDeletedSucessfully()
        {
            string Deletedalerttext = languagePageObj.GetDeletedLanguage(driver);
            Assert.That(Deletedalerttext == "French has been deleted from your languages", "Language is not deleted");
            
        }
    }
}
