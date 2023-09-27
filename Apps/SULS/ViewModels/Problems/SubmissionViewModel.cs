using System;

namespace SULS.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }
        public int AchievedResult { get; set; }
        public int MaxPoints { get; set; }
        public int Percentage => this.AchievedResult * 100 / this.MaxPoints;
        public DateTime CreatedOn { get; set; }
        public string SubmissionId { get; set; }
    }
}
