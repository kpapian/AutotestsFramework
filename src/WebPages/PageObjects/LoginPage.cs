using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using WebPages.PagesUtils;

namespace WebPages.PageObjects
{
    public class LoginPage : BasePage
    {
        #region PageLocators
        [FindsBy(How = How.Id, Using = "login_field")]
        private IWebElement _userNameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passwordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-block")]
        private IWebElement _signInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='js-flash-container']/div")]
        private IWebElement _errorMsgLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".auth-form-header >h1")]
        private IWebElement _signInLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".create-account-callout")]
        private IWebElement _createAccountLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".create-account-callout >a")]
        private IWebElement _createAccountLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".label-link")]
        private IWebElement _forgotPasswordLink { get; set; }
        #endregion

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage TypeUserName(String userName)
        {
            _userNameField.SendKeys(userName);            
            return this;
        }

        public LoginPage TypePassword(String password)
        {
            _passwordField.SendKeys(password);
            return this;
        }

        public Boolean IsErrorMessageLabelDisplayed()
        {
            return _errorMsgLabel.Displayed;
        }

        public String GetErrorMessageLabelText()
        {
            return _errorMsgLabel.Text;
        }

        public HomePage ClickSignInBtn()
        {
            _signInBtn.Click();
            return new HomePage(Driver);
        }

        public HomePage DoLogin(String userName, String password)
        {
            _userNameField.SendKeys(userName);
            _passwordField.SendKeys(password);
            _signInBtn.Click();
            Wait.PageLoad();
            return new HomePage(Driver);
        }

        public HomePage UserLogin(String userName, String password)
        {
            TypeUserName(userName);
            TypePassword(password);
            return ClickSignInBtn();
        }

        public String GetSignInLableText()
        {
            Driver.WaitForElementExists(_signInLabel, 2);//problem
            return _signInLabel.Text;
        }

        public Boolean IsForgotPasswordLinkPresent()
        {
            return _forgotPasswordLink.Displayed;
        }

        public Boolean IsCreateAccountLinkPresent()
        {
            return _createAccountLink.Displayed;
        }

        public Boolean IsCreateAccountLablePresent()
        {
            return _createAccountLabel.Displayed;
        }
    }
}
