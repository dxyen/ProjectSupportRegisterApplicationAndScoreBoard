using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.ViewModels
{
    public class UnacceptApplicationViewModel
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public string MSSV { get; set; }
        public string Class { get; set; }
        public string Course { get; set; }
        public string Teacher { get; set; }
        public DateTime DateRegis { get; set; }
        public string NameUnaccept { get; set; }
    }
}
