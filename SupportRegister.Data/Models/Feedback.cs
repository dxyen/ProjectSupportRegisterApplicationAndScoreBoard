using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Feedback
    {
        public int IdFeedback { get; set; }
        public int StudentId { get; set; }
        public string ContentFeedback { get; set; }

        public Student Student { get; set; }
    }
}
