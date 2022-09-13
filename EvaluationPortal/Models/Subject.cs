using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class Subject
    {
        public Subject()
        {
            QuestionBanks = new HashSet<QuestionBank>();
            TestAttendeeHistories = new HashSet<TestAttendeeHistory>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<QuestionBank> QuestionBanks { get; set; }
        public virtual ICollection<TestAttendeeHistory> TestAttendeeHistories { get; set; }
    }
}
