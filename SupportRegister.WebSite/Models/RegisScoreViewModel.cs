using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;

namespace SupportRegister.WebSite.Models
{
    public class RegisScoreViewModel
    {
        public List<YearSemesterViewModel> years { get; set; }
        public StudentViewModel students { get; set; }
        public List<RegisterScoreboardViewModel> regisStu { get; set; }
    }
}
