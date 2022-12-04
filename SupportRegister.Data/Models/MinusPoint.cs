using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Models
{
    public class MinusPoint
    {
        public int StudentId { get; set; }
        public int Id { get; set; }
        public string NameMinus { get; set; }
        public DateTime DateRegis { get; set; }

        public virtual Student Student { get; set; }
    }
}
