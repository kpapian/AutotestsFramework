using Autotests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using Service;
using CommonLib.Helpers.JsonHelper;
using System.Linq;
using CommonLib.Models;

namespace Autotests.Autotests
{
    [TestFixture]
    public class BaseTest
    {
        #region Registered user 
        protected UserData RegisteredUser = JsonDataHelper.UserData.First();
        #endregion

        protected IWebDriver Driver { get; set; }

        

        [OneTimeSetUp]
        public void CreateDriver()
        {
            ServiceManager.Initialize(GetConnectionString());
            Driver = DriverFactory.Create();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void DoAfterEachTest()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }

        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }
    }
}
