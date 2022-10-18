using System;
using MarsQA.Pages;
using MarsQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class CertificationsStepDefinitions : CommonDriver
    {
        ProfilePage profilePageObj = new ProfilePage();
        LoginPage loginPageObj = new LoginPage();
        CertificatePage certificatePageObj = new CertificatePage();

        [Given(@"I logged onto Mars portal successfully")]
        public void GivenILoggedOntoMarsPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();

            // Login page Object login and initialization and defination
            loginPageObj.LoginSteps(driver);
        }


        [When(@"I add certification to my profile")]
        public void WhenIAddCertificationToMyProfile()
        {
            profilePageObj.GoToProfilePage(driver);
            certificatePageObj.AddCertificate(driver);

        }

        [Then(@"New Certificate details will be added")]
        public void ThenNewCertificateDetailsWillBeAdded()
        {
            string certificate = certificatePageObj.GetActualCertificate(driver);
            string certificationFrom = certificatePageObj.GetActualCertificationFrom(driver);
            string certificationYear = certificatePageObj.GetActualCertificationYear(driver);

            Assert.That(certificate == "CAST", "Actual certificate and expected certificate do not match");
            Assert.That(certificationFrom == "Adobe", "Actual certificationfrom and expected certificationfrom do not match");
            Assert.That(certificationYear == "2016", "Actual certificationyear and expected certificationyear do not match");

        }

        [When(@"I update '([^']*)' , '([^']*)' , and '([^']*)'")]
        public void WhenIUpdateAnd(string Certificate, string From , string Year)
        {
            certificatePageObj.UpdateCertificate(driver, Certificate, From , Year);
        }

        [Then(@"The Certificate should should have edited'([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheCertificateShouldShouldHaveEditedAnd(string Certificate, string From, string Year)
        {
            string updatedcertificate = certificatePageObj.GetUpdatedCertificate(driver);
            string updatedcertificationFrom = certificatePageObj.GetUpdatedCertificationFrom(driver);
            string updatedcertificationYear = certificatePageObj.GetUpdatedCertificationYear(driver);

            Assert.That(updatedcertificate == Certificate , "Actual certificate and expected certificate do not match");
            Assert.That(updatedcertificationFrom == From , "Actual certificationfrom and expected certificationfrom do not match");
            Assert.That(updatedcertificationYear == Year , "Actual certificationyear and expected certificationyear do not match");
        }

        [When(@"I delete Certification from Certification record")]
        public void WhenIDeleteCertificationFromCertificationRecord()
        {
            certificatePageObj.DeleteCertification(driver);
        }

        [Then(@"The Certifications record should be deleted succesfully")]
        public void ThenTheCertificationsRecordShouldBeDeletedSuccesfully()
        {
            string Deletedalerttext = certificatePageObj.GetDeletedCertificate(driver);
            Assert.That(Deletedalerttext != "ISTQB has been deleted from your certification ", "Certification is not deleted");
        }
    }
}
