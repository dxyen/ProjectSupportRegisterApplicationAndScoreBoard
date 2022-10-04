using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Student
    {
        public Student()
        {
            Feedbacks = new HashSet<Feedback>();
            RegisterApplications = new HashSet<RegisterApplication>();
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int StudentId { get; set; }
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<RegisterApplication> RegisterApplications { get; set; }
        public ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
