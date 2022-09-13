using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class QuestionBank
    {
        public QuestionBank()
        {
            TestHistories = new HashSet<TestHistory>();
        }

        public int? SubjectId { get; set; }
        public int QuestionLevel { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<TestHistory> TestHistories { get; set; }
    }
}
