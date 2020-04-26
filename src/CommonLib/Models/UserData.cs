using System;

namespace CommonLib.Models
{
    public class UserData
    {
        public UserData()
        {

        }

        public UserData(String userName, String password)
        {
            UserName = userName;
            Password = password;
        }

        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public override string ToString()
        {
            return $"Login: {UserName} Password:{Password}";
        }
    }
}
