using System;
using MarsQA.Pages;
using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : CommonDriver
    {
        ProfilePage profilePageObj = new ProfilePage();
        LoginPage loginPageObj = new LoginPage();
        SkillsPage skillsPageObj = new SkillsPage();

        [Given(@"I logged on Mars portal successfully")]
        public void GivenILoggedOnMarsPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();

            // Login page Object login and initialization and defination
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I add Skills on my profile")]
        public void WhenIAddSkillsOnMyProfile()
        {
            profilePageObj.GoToProfilePage(driver);
            skillsPageObj.AddSkills(driver);
        }

        [Then(@"The Skills should be added sucessfully")]
        public void ThenTheSkillsShouldBeAddedSucessfully()
        {
            string Skill = skillsPageObj.GetActualSkills(driver);
            string level = skillsPageObj.GetSkillsLevel(driver);

            Assert.That(Skill == "Selenium", "Actual skill and expected skill do not match");
            Assert.That(level == "Expert", "Actual level and expected level do not match"); 
        }

        [When(@"I edit '([^']*)' and '([^']*)' on existing skill record")]
        public void WhenIEditAndOnExistingSkillRecord(string Skill, string Level)
        {
            skillsPageObj.UpdateSkills(driver, Skill, Level);
        }

        [Then(@"The record should have the updated '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string Skill, string Level)
        {
            string updatedSkills = skillsPageObj.GetUpdatedSkills(driver);
            string updatedlevel = skillsPageObj.GetUpdatedLevel(driver);

            Assert.That(updatedSkills == Skill , "Updated skill and expected skill do not match");
            Assert.That(updatedlevel == Level , "Actual level and expected level do not match"); ; ;
        }


        [When(@"I delete a Skill from an existing language record")]
        public void WhenIDeleteASkillFromAnExistingLanguageRecord()
        {
            skillsPageObj.Deleteskills(driver);
        }

        [Then(@"The Skill should be deleted sucessfully")]
        public void ThenTheSkillShouldBeDeletedSucessfully()
        {
            string Deletedalerttext = skillsPageObj.GetDeletedSkills(driver);
            Assert.That(Deletedalerttext != "Java has been deleted ", "Skill is not deleted");

        }
    }
}
