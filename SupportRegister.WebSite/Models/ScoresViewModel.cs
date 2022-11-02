using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;

namespace SupportRegister.WebSite.Models
{
    public class ScoresViewModel
    {
        public List<RegisterScoreboardViewModel> scores { get; set; }
        public RegisterScoreboardViewModel scoreDetail { get; set; }
    }
}
