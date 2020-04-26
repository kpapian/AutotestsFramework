using ApiUtility.Models.ApiRequestModels;
using ApiUtility.Models.ApiResponseModels;
using ApiUtility.Services;
using CommonLib.Attributes;
using NUnit.Framework;
using RestSharp;
using System;

namespace Autotests.Autotests
{
    public class APITests
    {
        private GitHubService _gitHubService;

        [Test, Api]
        [Description(@"
        1. Call UserInfo API via RestSharp lib.")]		
        public void ApiTestRestSharp()
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("/users/youruser", Method.GET);

            IRestResponse response = client.Execute(request);

            var content = response.Content;
        }

        [Test, Api]
        [Description(@"
        1. Call UserInfo API via HttpClient lib.
			Check:
			- Login is correct;
			- Type is correct;
            - Name is correct;
            - Company is correct;
            - Location is correct;
            - Bio is correct;
            - Count Of Public Repos is correct;")]
        public void GetUserInfoByUserName()
        {
            #region TestData
            String Login = "kpapian";
            String Type = "User";
            String Name = "Karina";
            String Company = "GL" ;
            String Location = "Ukraine";
            String Bio = "Automation QA, like programming.";
            Int32 CountOfPublicRepos = 6;
            #endregion

            APIResponseUserInfo userInfoResponse = GitHubService.GetUserInformation(new UserInfoRequestModel { UserName = Login });

            Assert.AreEqual(Login, userInfoResponse.Login,
                   "Login is correct");

            Assert.AreEqual(Type, userInfoResponse.Type,
                   "Type is correct");

            Assert.AreEqual(Name, userInfoResponse.Name,
                   "Name is correct");

            Assert.AreEqual(Company, userInfoResponse.Company,
                   "Company is correct");

            Assert.AreEqual(Location, userInfoResponse.Location,
                   "Location is correct");

            Assert.AreEqual(Bio, userInfoResponse.Bio,
                   "Bio is correct");

            Assert.AreEqual(CountOfPublicRepos, userInfoResponse.CountOfPublicRepos,
                   "Count Of Public Repos is correct");
        }

        private GitHubService GitHubService => _gitHubService ?? (_gitHubService = new GitHubService());
    }
}
