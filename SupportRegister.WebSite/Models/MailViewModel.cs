
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;

namespace SupportRegister.WebSite.Models
{
    public class MailViewModel
    {
        public List<EmailAdminViewModel> mails { get; set; }
        public EmailAdminViewModel mail { get; set; }
    }
}
