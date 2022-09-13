using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class TestAttendeeHistory
    {
        public TestAttendeeHistory()
        {
            TestHistories = new HashSet<TestHistory>();
        }

        public int QuestionPaperCode { get; set; }
        public int? SubjectId { get; set; }
        public DateTime ExamStartTime { get; set; }
        public DateTime ExamEndTime { get; set; }
        public int Experience { get; set; }
        public string DateOfExam { get; set; } = null!;

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<TestHistory> TestHistories { get; set; }
    }
}
