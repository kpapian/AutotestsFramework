using OpenQA.Selenium;
using System;
using WebPages.PageObjects;

namespace WebPages.PagesUtils
{
    public class Navigation
    {
        private IWebDriver _driver;
        private Wait _wait;

        public Navigation(IWebDriver driver)
        {
            _driver = driver;
            _wait = new Wait(_driver);
        }

        //public Navigation GoToPage(String url)
        //{
        //    _driver.Navigate().GoToUrl(url);
        //    _wait.PageLoad();

        //    return this;
        //}

        /// <summary>
        /// We set the type of expected page
        /// <returns></returns>
        /// </summary>
        public T GoToPage<T>(String url) where T : BasePage
        {
            _driver.Navigate().GoToUrl(url);
            _wait.PageLoad();

            return (T)Activator.CreateInstance(typeof(T), _driver);
        }

        public Navigation RefreshPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            _driver.Navigate().Refresh();
            _wait.PageLoad();
            return this;
        }

        public Navigation BackToPreviuosPage()
        {
            _driver.Navigate().Back();
            return this;
        }
    }
}
