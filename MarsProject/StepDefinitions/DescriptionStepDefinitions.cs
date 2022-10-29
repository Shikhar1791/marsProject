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
    public class DescriptionStepDefinitions : CommonDriver
    {
        DescriptionPage descriptionPageObj;
        ProfilePage profilePageObj;
        LoginPage loginPageObj;

        public DescriptionStepDefinitions()
        {
            this.descriptionPageObj = new DescriptionPage();
            this.profilePageObj = new ProfilePage();
            this.loginPageObj = new LoginPage();
        }

        [Given(@"I logged into Mars portal successfully")]
        public void GivenILoggedIntoMarsPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();

            // Login page Object login and initialization and defination
            loginPageObj.LoginSteps();
        }

        [When(@"I navigate to Profile page")]
        public void WhenINavigateToProfilePage()
        {
            profilePageObj.GoToProfilePage();
        }

        [When(@"I add new '([^']*)'")]
        public void WhenIAddNew(string description)
        {

            descriptionPageObj.AddDescription(driver, description);
        }

        [Then(@"the '([^']*)' should be created successfully")]
        public void ThenTheDescriptionShouldBeCreatedSuccessfully(string description)
        {
            string createdDescription = descriptionPageObj.GetProfileDescription(driver);
            Assert.That(createdDescription == description, "Actual description and expected description do not match");
        }


    }
}
