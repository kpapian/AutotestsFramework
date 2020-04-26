using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using WebPages.PagesUtils;

namespace WebPages.PageObjects
{
    public class SearchPage : BasePage
    {
        #region PageLocators

        [FindsBy(How = How.PartialLinkText, Using = "Users")]
        private IWebElement _usersTab;

        //private IWebElement _usersTab => Somemethod();

        //public IWebElement Somemethod()
        //{
        //    return Driver.FindElement(By.PartialLinkText("Users"));
        //}

        [FindsBy(How = How.XPath, Using = ".//*[@id='user_search_results']//em")]
        private IWebElement _userSearchResult { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Commits")]
        private IWebElement _commitsTab { get; set; }

        //[FindsBy(How = How.CssSelector, Using = ".h5")]//?
        //private IWebElement _commitsSearchResult { get; set; }        

        private IWebElement FindCommitForUser(String userName)
        {
            return Driver.FindElement(By.XPath($".//a[.='{userName}']/../../a[@class = 'h5 text-gray-dark']"));
        }
        #endregion

        public SearchPage(IWebDriver driver) : base(driver) { }

        public SearchPage ClickUsersTab()
        {
            _usersTab.Click();
            return this;
        }

        public SearchPage ClickCommitsTab()
        {
            _commitsTab.Click();
            return this;
        }

        public String GetUserNameSearchResult()
        {
            //WebDriverWait waitLoading = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //IWebElement searchResult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("user_search_results")));

            Driver.WaitForElementExists(_userSearchResult);
            return _userSearchResult.Text;
        }

        public String GetCommitTextSearchResult(String userName)
        {
            //WebDriverWait waitLoading = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //IWebElement searchResult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("commit_search_results")));
            
            Driver.WaitForElementExists(FindCommitForUser(userName));//problem
            return FindCommitForUser(userName).Text;
        }
    }
}
