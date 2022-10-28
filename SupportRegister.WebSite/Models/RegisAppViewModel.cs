using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;

namespace SupportRegister.WebSite.Models
{
    public class RegisAppViewModel
    {
        public List<ApplicationViewModel> app { get; set; }
        public ApplicationViewModel appDetails { get; set; }
        public RegisterApplicationViewModel appRegis { get; set; }

        public List<RegisterApplicationViewModel> allAppRegis { get; set; }
        public StudentAppViewModel students { get; set; }
    }
}
