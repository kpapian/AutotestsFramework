using CommonLib.Models;
using CommonLib.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebPages.PageObjects;
using WebPages.PagesUtils;

namespace Autotests.Autotests
{
    public class LoginTests : BaseTest
    {
        private static String ERROR_MESSAGE = "Incorrect username or password.";
        private static String SIGN_IN_LABEL = "Sign in to GitHub";

        private LoginPage _loginPage;
        private Navigation _navigation;
        private HomePage _homePage;

        public static List<UserData> GetDataForInvalidLogin()
        {
            List<UserData> list = new List<UserData>();
            list.Add(new UserData("kpapian", "2222"));
            list.Add(new UserData("2222", "kpapian"));
            list.Add(new UserData(Keys.Space, Keys.Space));
            list.Add(new UserData("", "12345"));
            list.Add(new UserData("kpapian", ""));

            return list;
        }

        [Test]
        [Description(@"
        Test steps:
        1. Open login page
        2. Type valid userName and password
        3. Click on signIn btn
            Check:           
            - Profile name is correct")]
        public void SignInValidUser()
        {
            Navigation
                .GoToPage<LoginPage>(SiteUrls.LoginPage)
                .TypeUserName(RegisteredUser.UserName)
                .TypePassword(RegisteredUser.Password)
                .ClickSignInBtn();

            Assert.IsTrue(HomePage.GetProfileName(RegisteredUser.UserName),
                "Profile name is correct");
        }

        [Test, TestCaseSource("GetDataForInvalidLogin")]
        [Description(@"
        Test steps:
        1. Open login page
        2. Type invalid userNmae or password
        3. Click on signIn btn
            Check:
            - 'Error message lable' has been dislyed
            - 'Error message lable' text is correct")]
        public void SignInInvalidUser(UserData invalidUser)
        {
            Navigation
                .GoToPage<LoginPage>(SiteUrls.LoginPage)
                .TypeUserName(invalidUser.UserName)
                .TypePassword(invalidUser.Password)
                .ClickSignInBtn();

            Assert.IsTrue(LoginPage.IsErrorMessageLabelDisplayed(),
                "'Error message lable' has been dislyed");

            Assert.AreEqual(ERROR_MESSAGE, LoginPage.GetErrorMessageLabelText(),
                "'Error message lable' text is correct");
        }

        [Test]
        [Description(@"
        Test steps:
        1. Open login page        
            Check:
            - 'Sign in' lable text is correct
            - 'Forgot password' link is present
            - 'Create account' lable is present
            - 'Create an account' link is present")]
        public void StaticContext()
        {
            Navigation
                .GoToPage<LoginPage>(SiteUrls.LoginPage);

            Assert.AreEqual(SIGN_IN_LABEL, LoginPage.GetSignInLableText(),
                "'Sign in' lable text is correct");

            Assert.IsTrue(LoginPage.IsForgotPasswordLinkPresent(),
                "'Forgot password' link is present");

            Assert.IsTrue(LoginPage.IsCreateAccountLablePresent(),
                "'Create account' lable is present");

            Assert.IsTrue(LoginPage.IsCreateAccountLinkPresent(),
              "'Create an account' link is present");
        }

        private LoginPage LoginPage => _loginPage ?? (_loginPage = new LoginPage(Driver));
        private Navigation Navigation => _navigation ?? (_navigation = new Navigation(Driver));
        private HomePage HomePage => _homePage ?? (_homePage = new HomePage(Driver));

        //private LoginPage LoginPage
        //{
        //    get
        //    {
        //        if (_loginPage == null)
        //        {
        //            _loginPage = new LoginPage(Driver);
        //        }

        //        return _loginPage;
        //    }
        //}
    }
}
