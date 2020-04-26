using ApiUtility.Models.ApiRequestModels;
using ApiUtility.Models.ApiResponseModels;
using CommonLib.CommonUtils;
using System;

namespace ApiUtility.Services
{
    public class GitHubService
    {
        private HttpHelper _httpHelper;

        public GitHubService()
        {
            _httpHelper = new HttpHelper();
        }

        //void IAuthService.Login<T>(T loginModel)
        //{
        //    APIResponseUserLogin response = LogedIn(loginModel);
        //    _httpHelper.Headers.Add("sessionId", response.SessionId);
        //}

        //public APIResponseUserLogin LogedIn<T>(T userModel)
        //{
        //    return _httpHelper.Post<APIResponseUserLogin>(ApiUrl.LoginApiUrl, userModel);
        //}

        //public void AddToCard(string sessionId)
        //{
        //    AddSessionHeader(sessionId);
        //}

        public APIResponseUserInfo GetUserInformation(UserInfoRequestModel model)
        {
            return _httpHelper.Get<APIResponseUserInfo>($"{ApiUrls.GetUserInfo}{model.UserName}");
        }

        private void AddSessionHeader(string sessionId)
        {
            if (_httpHelper.Headers.ContainsKey("session-id"))
            {
                _httpHelper.Headers["session-id"] = sessionId;
            }
            throw new NotImplementedException();
        }

        public void Logout()
        {
            _httpHelper.Headers.Clear();
        }
    }
}
