using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace WebPages.PageObjects
{
    public class HomePage : BasePage
    {
        #region PageLocators
        public IWebElement GetUserProfileName(string userName)
        {
            return Driver.FindElement(By.XPath($".//summary/img[@alt='@{userName}']"));
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchField { get; set; }
        #endregion        

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool GetProfileName(string userName)
        {
            try
            {
                GetUserProfileName(userName).Click();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public SearchPage TypeIntoSearchField(String text = null)
        {
            _searchField.SendKeys(text + Keys.Enter);
            return new SearchPage(Driver);
        }      
    }
}
