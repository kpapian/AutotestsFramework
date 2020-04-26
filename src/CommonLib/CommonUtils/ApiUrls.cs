using CommonLib.Utils;
using System;

namespace CommonLib.CommonUtils
{
    public class ApiUrls
    {
        public static String BaseApiUrl => "https://api.github.com";

        public static String GetUserInfo => $"{BaseApiUrl}/users/";
    }
}
