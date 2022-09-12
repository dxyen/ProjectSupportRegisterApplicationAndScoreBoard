using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Utilities.SystemConstants
{
    public class SystemConstants
    {
        public const string MAIN_CONNECTION_STRING = "DefaultConnection";
        public const string DEFAULT_AVATAR_URL = "/user-content/default-avatar.png";
        public const string DEFAULT_AVATAR_CAPTION = "Avatar image";

        public class AppSettings
        {
            public const string Token = "Token";
            public const string ApiAddress = "ApiAddress";
            public const string ImageUrl = "https://localhost:5001/user-content";
        }
    }
}
