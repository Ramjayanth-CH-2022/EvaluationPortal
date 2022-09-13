using System;
using System.Collections.Generic;

namespace EvaluationPortal.Models
{
    public partial class User
    {
        public User()
        {
            TestHistories = new HashSet<TestHistory>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }

        public virtual ICollection<TestHistory> TestHistories { get; set; }
    }
}
