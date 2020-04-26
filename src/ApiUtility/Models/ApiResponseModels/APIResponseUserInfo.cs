using Newtonsoft.Json;
using System;

namespace ApiUtility.Models.ApiResponseModels
{
    public class APIResponseUserInfo
    {
        public String Login { get; set; }
        public Int32 Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public String Company { get; set; }
        public String Location { get; set; }
        public String Bio { get; set; }

        [JsonProperty(PropertyName = "public_repos")]
        public Int32 CountOfPublicRepos { get; set; }
    }
}
