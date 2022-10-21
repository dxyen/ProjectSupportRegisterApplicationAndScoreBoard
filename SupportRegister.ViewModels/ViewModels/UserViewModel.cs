using SupportRegister.Utilities.SystemConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.ViewModels
{
    public class UserViewModel
    {
        public IList<string> Roles { get; set; }

        private string _avatarUrl;

        public string AvatarUrl
        {
            get => string.IsNullOrEmpty(_avatarUrl) ? SystemConstants.DEFAULT_AVATAR_URL : _avatarUrl;
            set => _avatarUrl = value;
        }

        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
