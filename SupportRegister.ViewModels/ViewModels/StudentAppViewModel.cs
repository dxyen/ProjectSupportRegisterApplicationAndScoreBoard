using System;

namespace SupportRegister.ViewModels.ViewModels
{
    public class StudentAppViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string ClassName { get; set; }
        public string Course { get; set; }
    }
}
