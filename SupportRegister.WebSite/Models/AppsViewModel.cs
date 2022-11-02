using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;

namespace SupportRegister.WebSite.Models
{
    public class AppsViewModel
    {
        public List<RegisterApplicationViewModel> apps { get; set; }
        public RegisterApplicationViewModel appDetail { get; set; }
    }
}
