using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Users
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập Mã số sinh viên!")]
        [Display(Name = "Username:", Prompt = "MSSV...")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:", Prompt = "********")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
            ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự, một chữ số, một chữ hoa, một ký tự không phải chữ và số!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [Compare("Password", ErrorMessage = "Mật khẩu và Mật khẩu xác nhận phải khớp!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Password:", Prompt = "********")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        [Display(Name = "Full Name:", Prompt = "Họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:", Prompt = "example@example.com")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được trống!")]
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public Guid RoleId { get; set; }
    }
}
