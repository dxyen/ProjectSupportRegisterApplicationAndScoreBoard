using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Users
{
    public class AccountChangePassword
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ:", Prompt = "Mật khẩu cũ")]
        public string PasswordCurrent { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới:", Prompt = "Mật khẩu mới")]
        public string PasswordNew { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu:", Prompt = "Mật khẩu mới")]
        public string PasswordNewComfirm { get; set; }
    }
}
