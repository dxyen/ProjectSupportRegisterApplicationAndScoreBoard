using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Student
    {
        public Student()
        {
            DetailRegisterScoreboards = new HashSet<DetailRegisterScoreboard>();
            RegisterApplications = new HashSet<RegisterApplication>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int StudentId { get; set; }
        public Guid UserId { get; set; }
        public int YearStart { get; set; }
        public int ClassId { get; set; }
        public string IdCourse { get; set; }
        public int YearEnd { get; set; }

        public Class Class { get; set; }
        public Course IdCourseNavigation { get; set; }
        public AppUser User { get; set; }
        public ICollection<RegisterApplication> RegisterApplications { get; set; }
        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
