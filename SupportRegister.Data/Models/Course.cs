using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public string IdCourse { get; set; }
        public string NameCourse { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
