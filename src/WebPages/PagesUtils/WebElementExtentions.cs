using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebPages.PagesUtils
{
    public static class WebElementExtentions
    {
        public static void Type(this IWebElement element, String value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void TypeAndClickEnter(this IWebElement element, String value)
        {
            element.Clear();
            element.SendKeys(value);
            element.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Check that element exist in DOM model (but can be hidden on UI)
        /// </summary>
        public static Boolean IsElemenExist(this IWebDriver driver, IWebElement element, Int32 implicitWait = 0)
        {
            Boolean flag = false;

            try
            {
                //сетит новое знаение имплисит вейту
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
                flag = element.Size.Height > 0; //если у элемента проперти высота больше 0 - значит такой элемент есть на стр, если бы не было - то при обращении к элементу - он бы упал с эксепшином
                flag = true;
            }

            catch (Exception e)
            {
                //ignore
            }

            finally
            {
                //возвращает имплисит вейт его дефолтное значение по ожиданию
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }

            return flag;
        }

        public static Boolean IsElementExist(this IWebDriver driver, By by, Int32 implicitlyWait = 0)
        {
            Boolean flag = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitlyWait);
                flag = driver.FindElements(by).Count > 0;
            }
            catch
            {
                // ignored
            }

            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }
            return flag;
        }

        /// <summary>
        /// Check for element displayed on UI 
        /// </summary>
        public static Boolean IsElementPresent(this IWebDriver driver, By by, Int32 implicitlyWait = 0)
        {
            Boolean flag = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitlyWait);
                IWebElement element = driver.FindElement(by);
                flag = element.Displayed;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }
            catch
            {
                // ignored
            }

            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }
            return flag;
        }

        public static Boolean IsElementPresent(this IWebDriver driver, IWebElement element, Int32 implicitlyWait = 0)
        {
            Boolean flag = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitlyWait);
                flag = element.Displayed;
            }
            catch { }

            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }
            return flag;
        }

        public static void WaitForElementExists(this IWebDriver driver, By by, Int32 timeOutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void WaitForElementExists(this IWebDriver driver, IWebElement element, Int32 timeOutInSeconds = 30)
        {
            Int32 timeoutSecs = timeOutInSeconds * 10;
            while (timeoutSecs-- > 0)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);                    
                    Boolean isDisplayed = element.Displayed;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
                    return;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
            }
            throw new NoSuchElementException();
        }

        public static void WaitForElementVisible(this IWebDriver driver, By by)
        {
            Int32 timeOutInSeconds = Wait.defaultTimeout;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForElementVisible(this IWebDriver driver, IWebElement element)
        {
            Int32 timeOutInSeconds = Wait.defaultTimeout;

            for (Int32 i = timeOutInSeconds * 10; i > 0; i--)
            {
                if (element.Displayed && element.Size.Height > 0 && element.Size.Width > 0)
                {
                    return;
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
            throw new Exception(String.Format("Element {0} is not visible.", element));
        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();
            Thread.Sleep(500);
        }

        public static void MoveToElement(this IWebDriver driver, By by)
        {
            Actions builder = new Actions(driver);
            IWebElement element = driver.FindElement(by);
            builder.MoveToElement(element).Build().Perform();
            Thread.Sleep(500);
        }

        public static void MoveToElementAndClick(this IWebDriver driver, IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();
            Thread.Sleep(500);
            element.Click();
        }

        public static void MoveToElementAndClick(this IWebDriver driver, By by)
        {
            Actions builder = new Actions(driver);
            IWebElement element = driver.FindElement(by);
            builder.MoveToElement(element).Build().Perform();
            Thread.Sleep(500);
            element.Click();
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, By by)
        {
            Int32 timeOutInSeconds = Wait.defaultTimeout;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, IWebElement element)
        {
            Int32 timeOutInSeconds = Wait.defaultTimeout;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
