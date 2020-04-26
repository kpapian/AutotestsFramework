using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages.PageObjects
{
    public class HelpPage : BasePage
    {
        #region PageLocators

        [FindsBy(How = How.XPath, Using = ".//input[@class='ais-SearchBox-input']")]
        private IWebElement _searchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".search-form-btn")]
        private IWebElement _searchBtn { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Ignoring files")]
        private IWebElement _searchResult { get; set; }

        #endregion

        public HelpPage(IWebDriver driver) : base(driver) { }

        public HelpPage TypeIntoSearchField(String text)
        {
            _searchField.SendKeys(text);
            return this;
        }

        public HelpPage ClickSearchButton()
        {
            _searchBtn.Click();
            return new HelpPage(Driver);
        }

        public String GetTextBySearch()
        {
            //WebDriverWait waitLoading = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //IWebElement searchResult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='search-container']//li[1]/h3")));
            Wait.Seconds(3);
            return _searchResult.Text;
        }
    }
}
