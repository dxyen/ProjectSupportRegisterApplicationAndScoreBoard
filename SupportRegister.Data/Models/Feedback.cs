using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class Feedback
    {
        public int IdFeedback { get; set; }
        public int StudentId { get; set; }
        public string NameFeedback { get; set; }

        public virtual Student Student { get; set; }
    }
}
