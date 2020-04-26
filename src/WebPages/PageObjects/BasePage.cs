using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebPages.PagesUtils;

namespace WebPages.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver { get; private set; }

        public Wait Wait { get; }        

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
            Wait = new Wait(driver);
        }
    }
}
