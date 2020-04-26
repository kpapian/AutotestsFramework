using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebPages.PagesUtils
{
    public class Wait
    {
        private IWebDriver _driver;

        public static readonly Int32 defaultTimeout = 20;

        public Wait(IWebDriver driver)
        {
            _driver = driver;
        }

        public void PageLoad(Int32 timeout = 30)
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }

        public void Seconds(Int32 time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }
    }
}
