using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Users
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập MSSV")]
        [Display(Name = "Username :", Prompt = "Tên người dùng")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:", Prompt = "Mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
