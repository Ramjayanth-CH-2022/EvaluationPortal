using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class QuestionPattern
    {
        public int Id { get; set; }
        public int MinimumExperience { get; set; }
        public int MaximumExperience { get; set; }
        public int? BasicNumberOfQuestion { get; set; }
        public int? IntermediateNumberOfQuestion { get; set; }
        public int? AdvanceNumberOfQuestion { get; set; }
    }
}
