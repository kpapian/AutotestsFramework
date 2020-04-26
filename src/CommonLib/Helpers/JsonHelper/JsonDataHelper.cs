using CommonLib.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CommonLib.Helpers.JsonHelper
{
    public static class JsonDataHelper
    {
        public static List<UserData> UserData { get; }

        static JsonDataHelper()
        {
            UserData = JsonConvert.DeserializeObject <List<UserData>>(FileHelper.GetText(@"\JsonFiles\UserData.json"));
        }
    }
}
