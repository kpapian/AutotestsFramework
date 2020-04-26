using CommonLib.Utils;
using NUnit.Framework;
using System;
using WebPages.PageObjects;
using WebPages.PagesUtils;

namespace Autotests.Autotests
{
    public class SearchTests : BaseTest
    {
        private HomePage _homePage;
        private SearchPage _searchPage;
        private LoginPage _loginPage;
        private HelpPage _helpPage;
        private Navigation _navigation;

        [Test]
        [Description(@"
        Test steps:
        1. Open Home page as not logged user
        2. In search field type userName = kpapian 
        3. Click Enter
        4. Open 'Users' tab
            Check:           
            - User name is exist")]
        public void SearchByUserName()
        {
            #region Precondition
            String userName = "kpapian";
            #endregion

            Navigation
                .GoToPage<HomePage>(SiteUrls.BaseUrl)
                .TypeIntoSearchField(userName)
                .ClickUsersTab();

            Assert.AreEqual(userName, SearchPage.GetUserNameSearchResult(),
                "User name is exist");
        }

        [Ignore("Useful test")]
        [Test]
        [Description(@"
        Test steps:
        1. Open Home page as not logged user
        2. In search field type commitName = Added SearchPage Page object
        3. Click Enter
        4. Open 'Users' tab
            Check:           
            - Commit name is exist")]
        public void SearchByCommits()
        {
            #region Precondition
            String commitName = "Added SearchPage Page object";
            #endregion

            Navigation
                .GoToPage<HomePage>(SiteUrls.BaseUrl)
                .TypeIntoSearchField(commitName)
                .ClickCommitsTab();
                                                                                                                                                        
            StringAssert.Contains(commitName, SearchPage.GetCommitTextSearchResult(RegisteredUser.UserName),
                "Commit name is exist");
        }

        [Test]
        [Description(@"
        Test steps:
        1. Login to the site
        2. Open Help page
        3. In search field type text = Ignoring files
            Check:           
            - Helper article is exists")]
        public void SearchByHelpPage()
        {
            #region Preconditions 
            String text = "Ignoring files";

            Navigation
                .GoToPage<LoginPage>(SiteUrls.LoginPage)
                .DoLogin(RegisteredUser.UserName, RegisteredUser.Password);
            #endregion

            Navigation
                .GoToPage<HelpPage>(SiteUrls.HelpPage)
                .TypeIntoSearchField(text);

            StringAssert.Contains(text, HelpPage.GetTextBySearch(),
                "Helper article is exists");
        }

        private HomePage HomePage => _homePage ?? (_homePage = new HomePage(Driver));
        private SearchPage SearchPage => _searchPage ?? (_searchPage = new SearchPage(Driver));
        private Navigation Navigation => _navigation ?? (_navigation = new Navigation(Driver));
        private LoginPage LoginPage => _loginPage ?? (_loginPage = new LoginPage(Driver));
        private HelpPage HelpPage => _helpPage ?? (_helpPage = new HelpPage(Driver));
    }
}
