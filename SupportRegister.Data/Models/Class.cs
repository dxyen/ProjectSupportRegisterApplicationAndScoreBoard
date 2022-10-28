using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Models
{
    public class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string NameClass { get; set; }
        public string Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
