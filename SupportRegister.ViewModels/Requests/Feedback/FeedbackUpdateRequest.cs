using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Feedback
{
    public class FeedbackUpdateRequest
    {
        public int IdFeedback { get; set; }
        public int StudentId { get; set; }
        public string ContentFeedback { get; set; }
    }
}
