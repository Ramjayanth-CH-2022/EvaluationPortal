using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class TestHistory
    {
        public int SerialNumber { get; set; }
        public int? UserId { get; set; }
        public int? QuestionPaperCode { get; set; }
        public int? QuestionId { get; set; }
        public string OptionChosen { get; set; } = null!;

        public virtual QuestionBank? Question { get; set; }
        public virtual TestAttendeeHistory? QuestionPaperCodeNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
